
library(tidyverse)
library(readr)
library(broom)
library(stringr)
library(forcats)
library(officer)
# library(viridis)

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


# report_date <- format(Sys.Date(), "%d %b %Y")
# 
# addSlideWithFooter <- function(mydoc, slide.layout, myfooter = paste("Australian Consumer Health Sales Trends in Retail Pharmacy IMS", monthfullyear, "data")) {
#   mydoc <- mydoc %>% addSlide(slide.layout = slide.layout) %>%
#     addFooter(myfooter)
#   
#   mydoc
# }



myppt <- read_pptx(path = "IQVIA_Master_2019.pptx")