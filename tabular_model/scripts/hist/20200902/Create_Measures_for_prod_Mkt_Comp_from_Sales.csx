foreach(var m in Selected.Measures) {
    var prod_dax = "if([f_SKUSelected], [$$$$], calculate([$$$$], filter(all('Dim_Product'[Product Ownership]), 'Dim_Product'[Product Ownership] = \"Own Products\")))";
    var mkt_dax = "var p_market = CALCULATE ( [$$$$], ALL ( 'Dim_Product'[Product Ownership] ), allselected('Dim_Product'[APN]), allselected('Dim_Product'[Brand]),\r\n" +
                    "allselected('Dim_Product'[Manufacturer]), allselected('Dim_Product'[Pack Long Name]), allselected('Dim_Product'[PFC]),allselected('Dim_Product'[Sub Brand]))\r\n" +
                    "var owner_market = CALCULATE ( [$$$$], ALL ( 'Dim_Product'[Product Ownership] ) )\r\n" +
                    "var finalval = if([f_SKUSelected], p_market, owner_market)\r\n" +
                    "return finalval";      
    var comp_dax = "if([f_SKUSelected], [$$$$], calculate([$$$$], filter(all('Dim_Product'[Product Ownership]), 'Dim_Product'[Product Ownership] = \"Competitor\")))";
    var shr_dax = "DIVIDE ( [$$$$], [####] )";

    var mname = m.Name;
    var dax_script = "";
    var prod_name = "Prod Sales";
    var mkt_name = "Mkt Sales";
    var comp_name = "Comp Sales";
    var shr_name = "% Mkt Shr";
    
    prod_dax = prod_dax.Replace("$$$$", mname);
    mkt_dax = mkt_dax.Replace("$$$$", mname);
    comp_dax = comp_dax.Replace("$$$$", mname);

    mname = mname.Replace("Sales", String.Empty);
    prod_name = mname + prod_name;
    mkt_name = mname + mkt_name;
    comp_name = mname + comp_name;
    shr_name = mname + shr_name;
    
    shr_dax = shr_dax.Replace("$$$$", prod_name).Replace("####", mkt_name);
    
    m.Table.AddMeasure(
        prod_name,                                       // Name
        FormatDax(prod_dax),     // DAX expression
        "Current Period Metrics"                                        // Display Folder
    );
    
    m.Table.AddMeasure(
        mkt_name,                                       // Name
        FormatDax(mkt_dax),     // DAX expression
        "Current Period Metrics"                                        // Display Folder
    );
    
    m.Table.AddMeasure(
        comp_name,                                       // Name
        FormatDax(comp_dax),     // DAX expression
        "Current Period Metrics"                                        // Display Folder
    );

    m.Table.AddMeasure(
        shr_name,                                       // Name
        FormatDax(shr_dax),     // DAX expression
        "Current Period Metrics"                                        // Display Folder
    );

}