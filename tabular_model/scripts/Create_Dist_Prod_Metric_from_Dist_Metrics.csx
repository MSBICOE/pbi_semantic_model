foreach(var m in Selected.Measures) {
    var prod_dax = "if([f_SKUSelected], [$$$$], calculate([$$$$], filter(all('Dim_Product'[Product Ownership]), 'Dim_Product'[Product Ownership] = \"Own Products\")))";

    var mname = m.Name;
    var prod_name = " Prod";

    prod_dax = prod_dax.Replace("$$$$", mname);

    prod_name = mname + prod_name;

    
    m.Table.AddMeasure(
        prod_name,                                       // Name
        FormatDax(prod_dax),     // DAX expression
        "Current Dist Metrics"                                        // Display Folder
    );
    

}