// Creates context all selected measure for contribution calculation
foreach(var m in Selected.Measures) {
    var exp = m.Expression;
    var mname = m.Name;
                     
    mname = mname.Replace("In Promo", "No Promo");
    // exp = exp.Replace("= 1", "= 0");  //// This is used for amount and unit
    exp = exp.Replace("In Promo", "No Promo");

    
    m.Table.AddMeasure(
        mname,                                       // Name
        FormatDax(exp),     // DAX expression
        "Price Metrics"                                        // Display Folder
    );

}