// Creates context all selected measure for contribution calculation
foreach(var m in Selected.Measures) {
    var mbase = Model.Tables["Fact_Banner_Brick_Sales"].Measures["BB Val Sales Multiple Cat Template"];
    var exp_base = mbase.Expression;
    var exp = m.Expression;
    var mname = m.Name;
    var mreplace = "Base " + m.Name;
    var mcreate = m.Name + " Original";
    
    mname = mname.Replace(" Multiple Cat", "");
    
    exp_base = exp_base.Replace("BB Val Sales", mname);
    //exp = exp.Replace("Base BB Val Sales", mreplace);

    m.Expression = exp_base;
    
    //m.Expression = 
    //m.Table.AddMeasure(
    //    mcreate,                                       // Name
    //    exp,     // DAX expression
    //    "Current Period Metrics\\Discrete Metrics Original"                                        // Display Folder
    //);

}