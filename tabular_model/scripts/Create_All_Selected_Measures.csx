// Creates context all selected measure for contribution calculation
foreach(var m in Selected.Measures) {
    var allselect_dax = "VAR pt = [const_Selected_Period_Type]\r\n" +
                        "VAR cseqmat = [const_Selected_Period_Seq_Mat]\r\n" +
                        "var mat = [const_Selected_MAT_Year]\r\n" +
                        "var finalval_cp = if(not ISBLANK([$$$$]), calculate([Base $$$$]" +
                        ",FILTER (ALL ( 'Dim_Date' ),'Dim_Date'[Period Type] = pt && 'Dim_Date'[MAT Year] = mat && 'Dim_Date'[period_seq_mat] = cseqmat), allselected()))\r\n" +
                        "var finalval_mat = if(not ISBLANK([$$$$]), calculate([Base $$$$],\r\n" + 
                        "FILTER (ALL ( 'Dim_Date' ), 'Dim_Date'[Period Type] = pt && 'Dim_Date'[MAT Year] = mat ), allselected()))\r\n" +
                        "var finalval = switch(true(), [f_DimDate] && [f_MATYear], finalval_mat, finalval_cp)\r\n" +
                        "return finalval";
                     
                        allselect_dax = allselect_dax.Replace("$$$$", m.Name);           
    m.Table.AddMeasure(
        m.Name + " All Selected",                                       // Name
        allselect_dax,     // DAX expression
        "Current All Selected"                                        // Display Folder
    );
}
