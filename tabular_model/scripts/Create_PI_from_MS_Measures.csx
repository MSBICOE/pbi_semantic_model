foreach(var m in Selected.Measures) {
    var metric_dax = "divide([$$$$], [####]) * 100";

    var mname = m.Name;
    var pi_name = mname.Replace("% Mkt Shr", "PI");
    var val_name = mname;
    var val_name_all = val_name + " All Selected";

    metric_dax = metric_dax.Replace("$$$$", val_name).Replace("####", val_name_all);
    
    m.Table.AddMeasure(
        pi_name,                                       // Name
        metric_dax,     // DAX expression
        "Current Period Metrics\\Current MS"                                        // Display Folder
    );  
}