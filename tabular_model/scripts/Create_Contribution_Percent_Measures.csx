foreach(var m in Selected.Measures) {
    var contrib_dax = "divide([$$$$], [$$$$ All Selected])";
    var mkt_dax = "CALCULATE ( [$$$$ All Selected], ALL ( 'Dim_Product'[Product Ownership] ) )";
    var comp_dax = "calculate([$$$$ All Selected], filter(all('Dim_Product'[Product Ownership]), 'Dim_Product'[Product Ownership] = \"Competitor\"))";
    
    
    contrib_dax = contrib_dax.Replace("$$$$", m.Name);

    
    m.Table.AddMeasure(
    m.Name + " Contrib %",                                       // Name
        contrib_dax,     // DAX expression
        "Current Period Metrics"                                        // Display Folder
    );
}
