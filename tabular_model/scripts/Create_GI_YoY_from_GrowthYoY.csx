foreach(var m in Selected.Measures) {
    var metric_dax = "if(not isblank([####]), divide([$$$$] + 1, [####] + 1) * 100)";

    var mname = m.Name;
    var gi_name = mname.Replace("Gr % vs LY", "GI vs LY");
    var mname_all = mname + " All Selected";

    metric_dax = metric_dax.Replace("$$$$", mname).Replace("####", mname_all);
    
    m.Table.AddMeasure(
        gi_name,                                       // Name
        metric_dax,     // DAX expression
        "Year over Year Growth Index"                                        // Display Folder
    );  
}