library(tidyverse)
library(readr)
library(survival)
# library(PropCIs)
library(broom)
library(survminer)
library(stringr)
library(forcats)
library(officer)
# library(viridis)

## import self_writen functions for this stats
source("code/999_km_sa_libs.r")

##get prepared data
surv_tidy <- readRDS("data/surv_tidy.rds")

## get the figure names and preset parameter from csv file
fig_param <- read_csv("data/fig_list.csv")


param_df_allVs <- fig_param %>%
  select(-seq)

# View(param_df_allVs)

# lo <- layout_summary(myppt)

# lo[order(lo$layout), "layout"]

# [1] "Blank - IQVIA"                          "Closing - IQVIA"                        "Cover Blue - IQVIA"                     "Cover Charcoal - IQVIA"                
# [5] "Cover Co-Brand - IQVIA"                 "Cover Green - IQVIA"                    "Cover Orange - IQVIA"                   "Cover White - IQVIA"                   
# [9] "Divider - IQVIA"                        "Divider Light Grey - IQVIA"             "Divider Photo Left - IQVIA"             "Divider Photo Right - IQVIA"           
# [13] "Half Photo Left - IQVIA"                "Half Photo Right - IQVIA"               "Logo Only - IQVIA"                      "Quote - IQVIA"                         
# [17] "Table of Contents - IQVIA"              "Table of Contents_Two Column - IQVIA"   "Thought Slide - IQVIA"                  "Three Column - IQVIA"                  
# [21] "Title and Content - IQVIA"              "Title and Content_Callout Opt1 - IQVIA" "Title and Content_Callout Opt2 - IQVIA" "Title and Content_Subhead - IQVIA"     
# [25] "Title and Subhead_Only - IQVIA"         "Title Only - IQVIA"                     "Two Column - IQVIA"                     "Two Column_NoSubhead - IQVIA" 


for (s in c("V1", "V2")) {
  
  myppt <- read_pptx(path = "IQVIA_Master_2019.pptx")
  
  myppt <- add_slide(myppt, layout = "Cover Blue - IQVIA", master = "IQVIA_V2.0.0")
  
  # slide_summary(myppt, index = 1)
  myppt <- ph_with(myppt, value = paste0("Astellas OBM Persistence Analysis Kaplan-Meier Curves Scenario: ", s), location = ph_location_label(ph_label = "Title 1"))
  
  myppt <- ph_with(myppt, value = "Prepared by IQVIA Data Science", location = ph_location_label(ph_label = "Text Placeholder 21"))
  
  myppt <- ph_with(myppt, value = "16 April 2020", location = ph_location_label(ph_label = "Subtitle 2"))
  
  param_df_all <- param_df_allVs %>% filter(Scenario == s)
  
  # for (i in seq_along(1:dim(param_df_all)[1])) {
  
  for (i in seq_along(1:dim(param_df_all)[1])) {
    # i = 1
    sc <- param_df_all[i,][[1]]
    gr <- param_df_all[i,][[2]]
    oab <- param_df_all[i,][[3]]
    group <- param_df_all[i,][[4]]
    fig <- param_df_all[i,][[5]]
    fig_name <- param_df_all[i,][[6]]
    fig_display <- param_df_all[i,][[7]] %>% str_replace(fixed("\\n"), "\n")
    fig_name <- paste0(fig, ", ", fig_name)
    fig_display <- paste0(fig, ", ", fig_display)
    
    image_name <- paste0("output/images/km_",
                         str_replace_all(fig, " ", "_"), "_",
                         sc, "_", gr, "_", oab, "_",
                         ifelse(group =="1", "Overall", group), ".png")
    
    p_title <- paste0("Survival Curve for Scenario: ", sc,
                      ", Strata: ", ifelse(group =="1", "Overall", group),
                      "\nGrace Period: ", str_replace(gr, "G", ""),
                      " Days, ", "OAB Experience: ", oab)
    
    # slice data
    s_df <- surv_df(surv_tidy, sc, gr, oab)
    
    km_curve <- plot_km(s_df, group, p_title, fig_display, image_name, save_image = FALSE)
    
    myppt <- add_slide(myppt, layout = "Title and Content - IQVIA", master = "IQVIA_V2.0.0")
    myppt <- ph_with(myppt, value = fig_name, location = ph_location_label(ph_label = "Title 1"))
    myppt <- ph_with(myppt, value = km_curve, location = ph_location_label(ph_label = "Content Placeholder 2"))
    myppt <- ph_with(myppt, value = paste0("Astellas Overactive Bladder Medication Persistence Analysis for Scenario ", s), 
                     location = ph_location_label(ph_label = "Footer Placeholder 4"))
    
    # km_curve
    
  }
  
  file_name <- paste0(s, "_Astellas_OAB_Analysis_KM_Curves_20200416.pptx")
  
  print(myppt, target = file_name)
}

