// Creates context all selected measure for contribution calculation
foreach(var m in Selected.Measures) {
    var oname = m.Name;
    var mname = m.DaxObjectName;
    var uname = mname.Replace("Prod", "Market");
    
    oname = oname.Replace("Prod", "MS");  

    var exp = "divide(" + mname + "," + uname + ")";
            
    m.Table.AddMeasure(
        oname,                                       // Name
        FormatDax(exp),     // DAX expression
        "MS Metrics"                                        // Display Folder
    );

}