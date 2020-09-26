foreach(var m in Selected.Measures) {
    var metric_dax = "if(not isblank([####]), divide([$$$$], [####]) * 100)";

    var mname = m.Name;
    var ei_name_yoy = mname.Replace("% Mkt Shr", "EI vs LY");
    var ei_name_pop = mname.Replace("% Mkt Shr", "EI vs PP");
    var ms_name_ly = mname + " LY";
    var ms_name_pp = mname + " PP";

    
    m.Table.AddMeasure(
        ei_name_yoy,                                       // Name
        metric_dax.Replace("$$$$", mname).Replace("####", ms_name_ly),     // DAX expression
        "Year over Year Evolution Index"                                        // Display Folder
        ).FormatString = "0";  
        
    m.Table.AddMeasure(
    ei_name_pop,                                       // Name
        metric_dax.Replace("$$$$", mname).Replace("####", ms_name_pp),     // DAX expression
        "Period over Period Evolution Index"                                        // Display Folder
        ).FormatString = "0";        
        
        
}

