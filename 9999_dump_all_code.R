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



dim_banner <- dbGetQuery(con_odbc,"Select * From vw_PBI_Dim_Banner")

try(dbRemoveTable(con_odbc_iqvia, 'dim_banner'), TRUE)
system.time(dbWriteTable(con_odbc_iqvia, 'dim_banner', as.data.frame(dim_banner)))




dim_product <- dbGetQuery(con_odbc,"Select * From vw_PBI_Dim_Product")

try(dbRemoveTable(con_odbc_iqvia, 'dim_product'), TRUE)
system.time(dbWriteTable(con_odbc_iqvia, 'dim_product', as.data.frame(dim_product)))

dbDisconnect(con_odbc)

dbDisconnect(con_odbc_iqvia)


library(collapsibleTree)
library(readxl)

Geography <- read_xlsx("data/Data_World.xlsx")


collapsibleTree(
  Geography,
  hierarchy = c("continent", "type", "country"),
  width = 800,
  zoomable = TRUE
)







```{sql, connection = con_odbc, echo = FALSE, output.var="Period_Type"}

SELECT [Period_Type]
,[Period_Name]
,[Period_Level_1]
,[Period_Level_2]
,[Period_Level_3]
FROM [dbo].[pbi_Period_Hierarchy];

```


```{r ptype, eval = TRUE, fig.cap="Period type and its rollup hierarchies"}
library(collapsibleTree)

Period_Type <- odbc::dbGetQuery(con_odbc, "
                              SELECT [Period_Type]
                                    ,[Period_Name]
                                    ,[Period_Level_1]
                                    ,[Period_Level_2]
                                    ,[Period_Level_3]
                              FROM [dbo].[pbi_Period_Hierarchy];
                                ")

collapsibleTree(
  Period_Type,
  hierarchy = c("Period_Type", "Period_Name", "Period_Level_1"),
  width = 800,
  zoomable = TRUE
)

```

library(collapsibleTree)
library(DiagrammeR)


