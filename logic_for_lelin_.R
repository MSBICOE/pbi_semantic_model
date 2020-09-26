library(tidyverse)
library(readxl)
library(tidyselect)
library(gtools)
#urn with 3 balls
ccc <- c("Budget.impact", "CostNomin", "CostNoeffectiveness", "high.unmet.need.", "STA.type...PBAC.")

x <- read_excel("data/pbs_3.xlsx", sheet = "s1", 
                col_types = c( "text", "text", "text", "text", "text", "text", "text", "text", "text", "text", "text", "numeric", 
                               "text", "text", "numeric", "text"))

cname <- make.names(names(x))


length(cname)
# cname_1

names(x) <- cname

x.1 <- x

# x.2 <- x

# x.2[, c("Budget.impact", "Cost.min", "Cost.effectiveness", "high.unmet.need.", "Submission.type")] <- "Any"
# 
# x <- bind_rows(x, x.2)


x_perm <- x

for (i in 1:5){
  # k <- 2
  col_s <- permutations(n=5,r=i,v=ccc)
  print(col_s)
  
  for (j in seq_along(1:dim(col_s)[1])) {
    
    x_col <- col_s[j, ]
    
    x.1[,x_col] <- "Any"
    
    x_perm <- bind_rows(x_perm, x.1)
    print(dim(x_perm))
    x.1 <- x
    
  }
}

x_finnal_1 <- distinct(x_perm) 

write_csv(x_finnal_1 , "data/lelin_new_1.csv")





ccc <- c("Budget.impact", "Cost.min", "Cost.effectiveness", "high.unmet.need.", "STA.type...PBAC.")

x <- read_excel("data/pbs_3.xlsx", sheet = "s2", 
                col_types = c( "text", "text", "text", "text", "text", "text", "text", "text", "text", "text", "text", "numeric", 
                               "text", "text", "text", "text"))

cname <- make.names(names(x))


length(cname)
# cname_1

names(x) <- cname



x.1 <- x

x_perm <- x

for (i in 1:5){
  # k <- 2
  col_s <- permutations(n=5,r=i,v=ccc)
  
  for (j in seq_along(1:dim(col_s)[1])) {
    
    x_col <- col_s[j, ]
    
    x.1[,x_col] <- "Any"
    
    x_perm <- bind_rows(x_perm, x.1)
    print(dim(x_perm))
    x.1 <- x
    
  }
}

x_finnal_2 <- distinct(x_perm) 

write_csv(x_finnal_2 , "data/lelin_new_2.csv")





c( "text", "text", "text", "text", "text", "text", "text", "text", "text", "text", "text", "numeric", 
   "text", "text", "text", "text", "numeric", "text", "text", "text", "text", "text", "text", "text", "text")

c( "text", "text", "text", "text", "text", "text", "text", "text", "text", "text", "text", "numeric", 
   "text", "text", "text", "text", "numeric", "text", "text", "text", "text", "text", "text")


c_others <- vars_select(cname, !matches(c("Budget.impact", "Cost.min", "Cost.effectiveness", "high.unmet.need.", "Submission.type")))



# TA.to.match, Drug, Drug.generic, Primary.therapeutic.area, Primary.disease,
# Route, Eligible.patient.count, GBA.assessment.date...manual., GBA.assessment.date..by.mol.., GBA.assessment.date...original.from.v12, 
# A.type...G.BA, PBAC.decision.date, STA.type...PBAC., time.from.GBA.to.PBS.listing., time.from.GBA.to.PBS.listing..old.,
# Best.rec, Multiple.recommendations., Latest.neg.rec.date, First.listing.date..new. 

# TA.to.match, Drug, Drug.generic,  Primary.therapeutic.area, Primary.disease,
# Route, Eligible.patient.count, GBA.assessment.date...manual, GBA.assessment.date..by.mol.., GBA.assessment.date...original.from.v12,
# STA.type...G.BA, PBAC.decision.date, STA.type...PBAC., time.from.GBA.to.PBS.listing., Best.rec,
# Multiple.recommendations.,  Latest.neg.rec.date,  First.listing.date 


x.1 <- x

x.1[, c("Budget.impact", "Cost.min", "Cost.effectiveness", "high.unmet.need.", "Submission.type")] <- x.1[, c("Budget.impact", "Cost.min", "Cost.effectiveness", "high.unmet.need.", "Submission.type")] %>% 
  replace(is.na(.), "UUUnk")

x.2 <- x.1 %>% 
  mutate(Budget.impact = "Any", 
         Cost.min = "Any", 
         Cost.effectiveness = "Any", 
         high.unmet.need. = "Any", 
         Submission.type = "Any")

x.3 <- bind_rows(x.1, x.2)

x.4 <- x.3 %>% ## select(TA.to.match, time.from.GBA.to.PBS.listing., time.from.GBA.to.PBS.listing..old., Budget.impact, Cost.min, Cost.effectiveness, high.unmet.need., Submission.type) %>%
  ## distinct() %>%
  complete(nesting(TA.to.match, Drug, Drug.generic, Primary.therapeutic.area, Primary.disease,
                   Route, Eligible.patient.count, GBA.assessment.date...manual., GBA.assessment.date..by.mol.., GBA.assessment.date...original.from.v12,
                   STA.type...G.BA, PBAC.decision.date, STA.type...PBAC., time.from.GBA.to.PBS.listing., time.from.GBA.to.PBS.listing..old.,
                   Best.rec, Multiple.recommendations., Latest.neg.rec.date, First.listing.date..new. ),
           Budget.impact, Cost.min, Cost.effectiveness, high.unmet.need., Submission.type) %>%
  select(cname)


x.4 <- x.3 %>% ## select(TA.to.match, time.from.GBA.to.PBS.listing., time.from.GBA.to.PBS.listing..old., Budget.impact, Cost.min, Cost.effectiveness, high.unmet.need., Submission.type) %>%
  ## distinct() %>%
  complete(nesting(TA.to.match, Drug, Drug.generic, Primary.therapeutic.area,
                   Route, Eligible.patient.count, GBA.assessment.date...manual., GBA.assessment.date..by.mol.., GBA.assessment.date...original.from.v12,
                   STA.type...G.BA, PBAC.decision.date, STA.type...PBAC., time.from.GBA.to.PBS.listing., time.from.GBA.to.PBS.listing..old.,
                   Best.rec, Multiple.recommendations., Latest.neg.rec.date, First.listing.date..new., Cost.min, Cost.effectiveness, high.unmet.need., Submission.type ),
           nesting(Primary.disease, Budget.impact)) %>%
  select(cname)

write_csv(x.4, "data/lelin.csv")

# x.4 <- x.3 %>% ## select(TA.to.match, time.from.GBA.to.PBS.listing., time.from.GBA.to.PBS.listing..old., Budget.impact, Cost.min, Cost.effectiveness, high.unmet.need., Submission.type) %>% 
#   ## distinct() %>% 
#   complete(nesting(TA.to.match, Drug, Drug.generic,  Primary.therapeutic.area, Primary.disease,
#                    Route, Eligible.patient.count, GBA.assessment.date...manual, GBA.assessment.date..by.mol.., GBA.assessment.date...original.from.v12,
#                    STA.type...G.BA, PBAC.decision.date, STA.type...PBAC., time.from.GBA.to.PBS.listing., Best.rec,
#                    Multiple.recommendations.,  Latest.neg.rec.date,  First.listing.date),
#            Budget.impact, Cost.min, Cost.effectiveness, high.unmet.need., Submission.type) %>% 
#   select(cname) 

x.4[, c("Budget.impact", "Cost.min", "Cost.effectiveness", "high.unmet.need.", "Submission.type")] <- x.4[, c("Budget.impact", "Cost.min", "Cost.effectiveness", "high.unmet.need.", "Submission.type")] %>% 
  replace(ifelse(. == "UUUnk", TRUE, FALSE), "")



write_csv(x.4, "data/lelin_1.csv")