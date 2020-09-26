// Creates context all selected measure for contribution calculation
foreach(var m in Selected.Measures) {
    var allselect_dax = "VAR pt = [const_Selected_Period_Type]\r\n" +
                        "VAR cseqmat = [const_Selected_Period_Seq_Mat]\r\n" +
                        "var mat = [const_Selected_MAT_Year]\r\n" +
                        "var cat = [const_Selected_Category]\r\n" +
                        "var finalval_cp = if(not ISBLANK([$$$$]), calculate([Base $$$$]" +
                        ",FILTER (ALL ( 'Dim_Date' ),'Dim_Date'[Period Type] = pt && 'Dim_Date'[MAT Year] = mat && 'Dim_Date'[period_seq_mat] = cseqmat), allselected()))\r\n" +
                        "var finalval_cp_cat = if(not ISBLANK([$$$$]), calculate([Base $$$$],\r\n" +
                        "FILTER (ALL ( 'Dim_Date' ),'Dim_Date'[Period Type] = pt && 'Dim_Date'[MAT Year] = mat && 'Dim_Date'[period_seq_mat] = cseqmat),FILTER (ALL ( 'Dim_Product' ),'Dim_Product'[Category] = cat),allselected()))\r\n" +
                        "var finalval_mat = if(not ISBLANK([$$$$]), calculate([Base $$$$],FILTER (ALL ( 'Dim_Date' ), 'Dim_Date'[Period Type] = pt && 'Dim_Date'[MAT Year] = mat ), allselected()))\r\n" +
                        "var finalval_mat_cat = if(not ISBLANK([$$$$]), calculate([Base $$$$],\r\n" +
                        "FILTER (ALL ( 'Dim_Date' ), 'Dim_Date'[Period Type] = pt && 'Dim_Date'[MAT Year] = mat ), FILTER (ALL ( 'Dim_Product' ),'Dim_Product'[Category] = cat), allselected()))\r\n" +
                        
                        
                        "var finalval = switch(true(), [f_DimDate] && [f_MATYear] && isblank(cat), finalval_mat, \r\n" +
                        "[f_DimDate] && [f_MATYear] && not isblank(cat), finalval_mat_cat, isblank(cat), finalval_cp, not isblank(cat), finalval_cp_cat, finalval_cp)\r\n" +
                        "return finalval";
                     
    allselect_dax = allselect_dax.Replace("$$$$", m.Name);           
    m.Table.AddMeasure(
        m.Name + " All Selected",                                       // Name
        FormatDax(allselect_dax),     // DAX expression
        "Current All Selected"                                        // Display Folder
    );
}
