library(htmltools)
library(flextable)
ft <- flextable(head(iris))
tab_list <- list()
for(i in 1:3){
  tab_list[[i]] <- tagList(
    tags$h6(paste0("iteration ", i)),
    htmltools_value(ft)
  )
}
tagList(tab_list)



library(odbc)
drv <- odbc::odbc()
connection <-  paste0("Driver={SQL Server Native Client 11.0};",    # Drivers
                      "Server=sydssql162d;", # Server Address
                      "Database=Adhoc;", # Database Name
                      "Trusted_Connection=yes;")

con_odbc <- dbConnect(drv,
                      .connection_string = connection, encoding = "latin1")


connection_iqvia <-  paste0("Driver={SQL Server Native Client 11.0};",    # Drivers
                            "Server=SQLETL02D.INT.MIPORTAL.COM;", # Server Address
                            "Database=iqviaau_reporting_db;", # Database Name
                            "Trusted_Connection=yes;")

con_odbc_iqvia <- dbConnect(drv,
                            .connection_string = connection_iqvia, encoding = "latin1")


connection_pcust <-  paste0("Driver={SQL Server Native Client 11.0};",    # Drivers
                      "Server=sydssql162d;", # Server Address
                      "Database=Product_Customization;", # Database Name
                      "Trusted_Connection=yes;")

con_odbc_pcust <- dbConnect(drv,
                      .connection_string = connection_pcust, encoding = "latin1")


connection_ever <-  paste0("Driver={SQL Server};",    # Drivers
                            "Server=sydssql95;", # Server Address
                            "Database=EverestParameters;", # Database Name
                            "Trusted_Connection=yes;")

con_odbc_ever <- dbConnect(drv,
                            .connection_string = connection_ever, encoding = "latin1")



dim_banner <- dbGetQuery(con_odbc,"Select * From vw_PBI_Dim_Banner")

try(dbRemoveTable(con_odbc_iqvia, 'dim_banner'), TRUE)
system.time(dbWriteTable(con_odbc_iqvia, 'dim_banner', as.data.frame(dim_banner)))




dim_product <- dbGetQuery(con_odbc,"Select * From vw_PBI_Dim_Product")

dim_store <- dbGetQuery(con_odbc,"Select * From vw_PBI_Dim_Store")

dim_sellin_scanout <- dbGetQuery(con_odbc_pcust,"SELECT * FROM [dbo].[pbi_Sellin_Scanout]")

dim_client_subscription <- dbGetQuery(con_odbc_ever,                                  "
                                  SELECT distinct
                                        [ClientNumber]
                                        ,[ClientName]
                                        ,[SubscriptionID]
                                        ,[Subscription]
                                        ,[SubscriptionEnddate]
                                        ,[DeliverableID]
                                        ,[Deliverable]
                                        ,[DeliveryEndDate]
                                        ,[Country]
                                        ,[Service]
                                        ,[DataType]
                                        ,[Source]
                                        ,[Delivery]
                                        ,[Frequency]
                                        ,[FrequencyType]
                                        ,[Period]
                                        ,[Restriction]
                                        ,[ReportWriterCode]
                                        ,[ReportWriterName]
                                        ,[MarketID]
                                        ,[MarketDimensionID]
                                        ,[MiPMktCode]
                                  FROM [dbo].[ReportParameter]
                                  Where
                                  --[ClientName] like 'bayer%consumer%'
                                  --And
                                  [Service] in ('Scan', 'Profits', 'Probe')
                                  And Source in ('Sell In', 'Sell Out')
                                  And Delivery in ('MiPortal', 'CBG Dashboard')
                                  and DataType not in ('Hospital')
                                      ")



try(dbRemoveTable(con_odbc_iqvia, 'dim_product'), TRUE)
system.time(dbWriteTable(con_odbc_iqvia, 'dim_product', as.data.frame(dim_product)))



period_hierarchy <- dbGetQuery(con_odbc_pcust,"select * from [dbo].[pbi_Period_Hierarchy]")

try(dbRemoveTable(con_odbc_iqvia, 'Admin_Config_Period_All'), TRUE)
system.time(dbWriteTable(con_odbc_iqvia, 'Admin_Config_Period_All', as.data.frame(period_hierarchy )))


try(dbRemoveTable(con_odbc_iqvia, 'dim_product'), TRUE)
system.time(dbWriteTable(con_odbc_iqvia, 'dim_product', as.data.frame(dim_product)))


try(dbRemoveTable(con_odbc_iqvia, 'dim_store'), TRUE)
system.time(dbWriteTable(con_odbc_iqvia, 'dim_store', as.data.frame(dim_store)))

try(dbRemoveTable(con_odbc_iqvia, 'dim_sellin_scanout'), TRUE)
system.time(dbWriteTable(con_odbc_iqvia, 'dim_sellin_scanout', as.data.frame(dim_sellin_scanout)))


try(dbRemoveTable(con_odbc_pcust, 'pbi_Client_Subscription'), TRUE)
system.time(dbWriteTable(con_odbc_pcust, 'pbi_Client_Subscription', as.data.frame(dim_client_subscription)))


try(dbRemoveTable(con_odbc_iqvia, 'dim_client_subscription'), TRUE)
system.time(dbWriteTable(con_odbc_iqvia, 'dim_client_subscription', as.data.frame(dim_client_subscription)))


dbDisconnect(con_odbc)

dbDisconnect(con_odbc_iqvia)

dbDisconnect(con_odbc_pcust)

dbDisconnect(con_odbc_ever)



# library(collapsibleTree)
# library(readxl)
# 
# Geography <- read_xlsx("data/Data_World.xlsx")
# 
# 
# collapsibleTree(
#   Geography,
#   hierarchy = c("continent", "type", "country"),
#   width = 800,
#   zoomable = TRUE
# )
# 



# 
# 
# 
# ```{sql, connection = con_odbc, echo = FALSE, output.var="Period_Type"}
# 
# SELECT [Period_Type]
# ,[Period_Name]
# ,[Period_Level_1]
# ,[Period_Level_2]
# ,[Period_Level_3]
# FROM [dbo].[pbi_Period_Hierarchy];
# 
# ```
# 
# 
# ```{r ptype, eval = TRUE, fig.cap="Period type and its rollup hierarchies"}
# library(collapsibleTree)
# 
# Period_Type <- odbc::dbGetQuery(con_odbc, "
#                               SELECT [Period_Type]
#                                     ,[Period_Name]
#                                     ,[Period_Level_1]
#                                     ,[Period_Level_2]
#                                     ,[Period_Level_3]
#                               FROM [dbo].[pbi_Period_Hierarchy];
#                                 ")
# 
# collapsibleTree(
#   Period_Type,
#   hierarchy = c("Period_Type", "Period_Name", "Period_Level_1"),
#   width = 800,
#   zoomable = TRUE
# )
# 
# ```
# 
# library(collapsibleTree)
# library(DiagrammeR)
# 

