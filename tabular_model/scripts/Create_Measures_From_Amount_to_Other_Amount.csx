// Creates context all selected measure for contribution calculation
foreach(var m in Selected.Measures) {
    var exp = m.Expression;
    var mname = m.Name;
    var replacevalue = "Incremental Amount";
                     
    mname = mname.Replace("Amount", replacevalue);
    exp = exp.Replace("Amount", replacevalue);
            
    m.Table.AddMeasure(
        mname,                                       // Name
        FormatDax(exp),     // DAX expression
        "Amount Metrics"                                        // Display Folder
    );

}