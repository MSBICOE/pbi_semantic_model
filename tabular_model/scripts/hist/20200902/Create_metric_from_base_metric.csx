var targetTable = Model.Tables["Fact_Banner_Brick_Sales"]; 
foreach(var m in Selected.Measures) {
    var base_dax = "VAR pt = [const_Selected_Period_Type]\r\n" +
                        "VAR cp = [const_Selected_Current_Period]\r\n" +
                        "VAR sales = CALCULATE ([$$$$],FILTER (ALL ( 'Dim_Date' ),'Dim_Date'[Period Type] = pt && 'Dim_Date'[Date Code] = cp))\r\n" +
                        "RETURN sales";
                     
    base_dax = base_dax.Replace("$$$$", m.Name);           
    targetTable.AddMeasure(
        m.Name.Replace("Base ", String.Empty),                                       // Name
        FormatDax(base_dax),     // DAX expression
        "Current Period Metrics"                                        // Display Folder
    );
}