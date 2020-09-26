//var targetTable = Model.Tables["Fact_Banner_Brick_Sales"]; 
foreach(var m in Selected.Measures) {
    var base_dax = "VAR pt = [const_Selected_Period_Type]\r\n" +
                        "VAR cp = [const_Selected_Current_Period]\r\n" +
                        "var cps = values('Dim_Date'[Date Code])\r\n" + 
                        "var f_date = [f_DimDate]\r\n" +
                        "VAR sales = CALCULATE ([$$$$],FILTER (ALL ( 'Dim_Date' ),'Dim_Date'[Period Type] = pt && 'Dim_Date'[Date Code] = cp))\r\n" +
                        "VAR sales_all = CALCULATE ([$$$$],FILTER (ALL ( 'Dim_Date' ),'Dim_Date'[Period Type] = pt&& 'Dim_Date'[Date Code] in cps))\r\n" +
                        "RETURN if(f_date, sales_all, sales)";
                     
    base_dax = base_dax.Replace("$$$$", m.Name);           
    m.Table.AddMeasure(
        m.Name.Replace("Base ", String.Empty),                                       // Name
        FormatDax(base_dax),     // DAX expression
        "Current Dist Metrics"                                        // Display Folder
    );
}
