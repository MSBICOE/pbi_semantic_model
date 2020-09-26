foreach(var m in Selected.Measures) {
    var shr_dax = "DIVIDE ( [$$$$], [####] )";

    var mname = m.Name;
    var so_name = "BB Scanout";
    var si_name = "BB Sellin";
    var sosi_name = "BB SO/SI";
    var sosi_dax = "";
    var ret_name = "BB Retail";
    var gr_name = "BB Grocery";
    var retgr_name = "BB Ret/Gr";
    var retgr_dax = "";
    
    
    so_name = mname.Replace("BB", so_name);
    si_name = mname.Replace("BB", si_name);
    sosi_name = mname.Replace("BB", sosi_name) + " Ratio";
    
    sosi_dax = shr_dax.Replace("$$$$", so_name).Replace("####", si_name);
    
    
    ret_name = mname.Replace("BB", ret_name);
    gr_name = mname.Replace("BB", gr_name);
    retgr_name = mname.Replace("BB", retgr_name) + " Ratio";
    
    retgr_dax = shr_dax.Replace("$$$$", ret_name).Replace("####", gr_name);
    
    
    
    m.Table.AddMeasure(
        sosi_name,                                       // Name
        sosi_dax,     // DAX expression
        "Current Period Metrics"                                        // Display Folder
    );
    
    m.Table.AddMeasure(
        retgr_name,                                       // Name
        retgr_dax,     // DAX expression
        "Current Period Metrics"                                        // Display Folder
    );
}
