// Creates context all selected measure for contribution calculation
foreach(var m in Selected.Measures) {
    var exp = m.Expression;
    var mname = m.Name;
                     
    mname = mname.Replace("Amount", "Unit");
    exp = exp.Replace("Amount", "Unit");
            
    m.Table.AddMeasure(
        mname,                                       // Name
        FormatDax(exp),     // DAX expression
        "Unit Metrics"                                        // Display Folder
    );

}