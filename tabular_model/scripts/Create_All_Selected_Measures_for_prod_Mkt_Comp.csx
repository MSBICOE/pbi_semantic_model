foreach(var m in Selected.Measures) {
    var prod_dax = "calculate([$$$$ All Selected], filter(all('Dim_Product'[Product Ownership]), 'Dim_Product'[Product Ownership] = \"Own Products\"))";
    var mkt_dax = "CALCULATE ( [$$$$ All Selected], ALL ( 'Dim_Product'[Product Ownership]) )";
    var comp_dax = "calculate([$$$$ All Selected], filter(all('Dim_Product'[Product Ownership]), 'Dim_Product'[Product Ownership] = \"Competitor\"))";

    var mname = m.Name;
    var dax_script = "";
    if (m.Name.Contains("Prod")) {
        mname = mname.Replace(" Prod", String.Empty);
        dax_script = prod_dax.Replace("$$$$", mname);
    } else if (m.Name.Contains("Mkt")) {
        mname = mname.Replace(" Mkt", String.Empty);
        dax_script = mkt_dax.Replace("$$$$", mname);
    } else if (m.Name.Contains("Comp")) {
        mname = mname.Replace(" Comp", String.Empty);
        dax_script = comp_dax.Replace("$$$$", mname);
    }
    
    m.Table.AddMeasure(
        m.Name + " All Selected",                                       // Name
        dax_script,     // DAX expression
        "Current All Selected"                                        // Display Folder
    );
}
