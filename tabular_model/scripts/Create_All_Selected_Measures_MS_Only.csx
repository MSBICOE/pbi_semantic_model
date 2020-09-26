// Creates context all selected measure for contribution calculation
foreach(var m in Selected.Measures) {
    var allselect_dax = "VAR pt = [const_Selected_Period_Type]\r\n" +
                        "VAR cp = [const_Selected_Current_Period]\r\n" +
                        "var f_date = [f_DimDate]\r\n" +
                        "var val_nocat = CALCULATE ([$$$$],FILTER (ALL ( 'Dim_Date' ),'Dim_Date'[Period Type] = pt && 'Dim_Date'[Date Code] = cp),ALLSELECTED ())\r\n" +
                        "var val_nocat_date = CALCULATE ([$$$$],FILTER (ALL ( 'Dim_Date' ),'Dim_Date'[Period Type] = pt), ALLSELECTED ())\r\n" +
                        "VAR val_currrent = IF (NOT ISBLANK ( [$$$$] ), val_nocat)\r\n" +
                        "VAR val_date_select = IF (NOT ISBLANK ( [$$$$] ), val_nocat_date)\r\n" +
                        "RETURN if(f_date, val_date_select, val_currrent)";
                     
    allselect_dax = allselect_dax.Replace("$$$$", m.Name);           
    m.Table.AddMeasure(
        m.Name + " All Selected",                                       // Name
        FormatDax(allselect_dax),     // DAX expression
        "Current All Selected"                                        // Display Folder
    );
}