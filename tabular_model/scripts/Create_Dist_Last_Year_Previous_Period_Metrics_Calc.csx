// Creates same period last year last year and previous period measure for every selected measure.
foreach(var m in Selected.Measures) {
    var ly_dax_part_1 = "var pt = [const_Selected_Period_Type]\r\n" +
                        "var lymat = [const_Selected_Last_MAT_Year]\r\n" +
                        "var seqmat = [const_Selected_Period_Seq_Mat]\r\n" +
                        "var lyvalue = calculate(";

    var ly_dax_part_2 = ", filter(all('Dim_Date'), 'Dim_Date'[MAT Year] = lymat && 'Dim_Date'[period_seq_mat] = seqmat && 'Dim_Date'[Period Type] = pt))\r\n" +
                        "return lyvalue";
                        
    var pp_dax_part_1 = "var pt = [const_Selected_Period_Type]\r\n" +
                        "var seq = [const_Selected_Period_Seq] + 1\r\n" +
                        "var lyvalue = calculate(";

    var pp_dax_part_2 = ", filter(all('Dim_Date'), 'Dim_Date'[period_seq] = seq && 'Dim_Date'[Period Type] = pt))\r\n" +
                        "return lyvalue";                        
                        
    m.Table.AddMeasure(
        m.Name + " LY",                                       // Name
        ly_dax_part_1 + m.DaxObjectName + ly_dax_part_2,     // DAX expression
        "Current Dist Metrics\\LY"                                        // Display Folder
    );
    
    m.Table.AddMeasure(
        m.Name + " PP",                                       // Name
        pp_dax_part_1 + m.DaxObjectName + pp_dax_part_2,     // DAX expression
        "Current Dist Metrics\\PP"                                        // Display Folder
    );
}