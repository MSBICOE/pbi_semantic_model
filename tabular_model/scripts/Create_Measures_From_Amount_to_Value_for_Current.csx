// Creates same period last year last year and previous period measure for every selected measure.
foreach(var m in Selected.Measures) {
    var oname = m.Name;
    var dname = m.DaxObjectName;
    var uname = dname.Replace("Amount", "Unit");
    //var measure = "Switch(True(), [const_Selected_Measure] = \"Unit\"," + uname + "," + dname + ")";
    var measure = dname;
    oname = "CP " + oname;
    
    //oname = oname.Replace("Amount", "Value");
    
    var dax = "VAR pt = [const_Selected_Period_Type] \r\n" +
    "VAR cp = [const_Current_Period] \r\n" +
    "var cps = values('Dim_Period'[period_name]) \r\n" +
    "VAR f_date = [ff_DimDate] \r\n" +
    "VAR sales = \r\n" +
    "CALCULATE ( \r\n" +
    "$$$$, \r\n" +
    "FILTER ( \r\n" +
    "ALL ( 'Dim_Period' ), \r\n" +
    "'Dim_Period'[period_type] = pt \r\n" +
    "&& 'Dim_Period'[period_name] = cp \r\n" +
    " ) \r\n" +
    ") \r\n" +
    "VAR sales_all = \r\n" +
    "CALCULATE ( \r\n" +
    "$$$$, \r\n" +
    "FILTER ( \r\n" +
    "ALL ( 'Dim_Period' ), \r\n" +
    "'Dim_Period'[period_type] = pt \r\n" +
    "&& 'Dim_Period'[period_name] IN cps \r\n" +
    ") \r\n" +
    ") \r\n" +
    "RETURN \r\n" +
    "IF ( f_date, sales_all, sales )";       

    dax = dax.Replace("$$$$", measure);
                        
    m.Table.AddMeasure(
        oname,                                       // Name
        FormatDax(dax),     // DAX expression
        "Current Metrics"                                        // Display Folder
    );
    
}