foreach(var m in Selected.Measures) {
    var metric_dax = "divide([$$$$], [####])";

    var mname = m.Name;
    var price_name = mname.Replace("Val", "Price");
    var val_name = mname;
    var unit_name = mname.Replace("Val", "Unit");

    //base_name = mname.Replace(bb_prefix, String.Empty).Replace(st_prefix, String.Empty);
    //f_mname = base_name.Replace(" Sales", String.Empty).Replace(" Count", " #");
    
    metric_dax = metric_dax.Replace("$$$$", val_name).Replace("####", unit_name);
    
    targetTable.AddMeasure(
        price_name,                                       // Name
        metric_dax,     // DAX expression
        "Current Price Metrics"                                        // Display Folder
    );  
}
