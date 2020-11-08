// Creates context all selected measure for contribution calculation
foreach(var m in Selected.Measures) {
    var oname = m.Name;
    var mname = m.DaxObjectName;
    var uname = mname.Replace("Amount", "Unit");
    
    oname = oname.Replace("Amount", "Price");  

    var exp = "divide(" + mname + "," + uname + ")";
            
    m.Table.AddMeasure(
        oname,                                       // Name
        FormatDax(exp),     // DAX expression
        "Price Metrics"                                        // Display Folder
    );

}