var targetTable = Model.Tables["Fact_Metrics"]; 
foreach(var m in Selected.Measures) {
    var metric_dax = "Switch(TRUE(), [const_Selected_Scan], switch(TRUE(), [f_CWHRelated] && not [f_CWHNotRelated], [$$$$],\r\n" +
                        "not [f_CWHRelated] && [f_ScanRelated] && Not [f_ScanNotRelated], [$$$$],\r\n" +
                        "[f_CWHRelated] || [f_ScanNotRelated] || [crossf_EID], Blank(),[$$$$]),\r\n" +
                        "[const_Selected_CBG], switch(TRUE(), [f_CBGRelated] && not [f_CBGNotRelated], [$$$$],\r\n" +
                        "[f_CBGNotRelated] || [crossf_EID], Blank(),[$$$$]),\r\n" +
                        "[const_Selected_Profit], switch(TRUE(), [f_ProfitRelated] && not [f_ProfitNotRelated],  [####],\r\n" +
                        "[f_ProfitNotRelated] || [crossf_EID] || [crossf_Brick], Blank(), [####]),\r\n" +
                        "[const_Selected_Probe], if([crossf_Brick], Blank(), calculate([####],\r\n" +
                        "Filter('Dim_Store', 'Dim_Store'[Store Type Description] = \"Retail Pharmacy\"))), BLANK())";

    var mname = m.Name;
    var base_name = "";
    var f_mname = "";
    var bb_prefix = "BB ";
    var st_prefix = "ST ";

    base_name = mname.Replace(bb_prefix, String.Empty).Replace(st_prefix, String.Empty);
    f_mname = base_name.Replace(" Sales", String.Empty).Replace(" Count", " #");
    
    metric_dax = metric_dax.Replace("$$$$", bb_prefix + base_name).Replace("####", st_prefix + base_name);
    
    targetTable.AddMeasure(
        f_mname,                                       // Name
        metric_dax,     // DAX expression
        "Current Period Metrics"                                        // Display Folder
    );  
}