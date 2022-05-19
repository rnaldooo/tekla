 private void button2_Click(object sender, EventArgs e)
        {
            TSM.Model model = new TSM.Model();


            ArrayList ObjectsToSelect = new ArrayList();

            TSM.ModelObjectEnumerator myEnum = model.GetModelObjectSelector().GetAllObjects();

            foreach (ModelObject obj in myEnum)
            {
                if (obj is Part)
                {
                    Part parte = obj as Part;
                    int numeroParafusos = parte.GetBolts().GetSize();
                    int numeroSolda = parte.GetWelds().GetSize();
                    //if ((numeroParafusos + numeroSolda) == 0)
                    {
                        ObjectsToSelect.Add(parte);
                        // MessageBox.Show("peça voando" + parte.PartNumber.Prefix.ToString());
                    }
                    numeroParafusos = 0;
                    numeroSolda = 0;
                }

            }

            Tekla.Structures.Model.UI.ModelObjectSelector MS = new Tekla.Structures.Model.UI.ModelObjectSelector();
            MS.Select(ObjectsToSelect);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Picker ppart = new Picker();
                ModelObject pobj = ppart.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Pick part");
                Part partt = pobj as Part;
                Assembly assembly = partt.GetAssembly();
                double COG_X_val = 0.0;
                double COG_Y_val = 0.0;
                double COG_Z_val = 0.0;
                assembly.GetReportProperty("COG_X", ref COG_X_val);
                assembly.GetReportProperty("COG_Y", ref COG_Y_val);
                assembly.GetReportProperty("COG_Z", ref COG_Z_val);
                // MessageBox.Show("cg: " + COG_X_val + "\n" + COG_Y_val + "\n" + COG_Z_val);
                string str = string.Empty;
                partt.GetUserProperty("comment", ref str);

                if (String.IsNullOrEmpty(str))
                {
                    partt.SetUserProperty("comment", COG_X_val + ";" + COG_Y_val + ";" + COG_Z_val);
                    MessageBox.Show("mudou para :" + str);
                }
                else
                {
                    MessageBox.Show("Existe um texto :" + str);
                }
            }
            catch (Exception eea)
            {
                //messeng
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {


            try
            {
                Picker ppart = new Picker();
                ModelObject pobj = ppart.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Pick viga");
                Beam viga = pobj as Beam;

                Picker pointpicker = new Picker();
                try
                {
                    ArrayList pPoints = pointpicker.PickPoints(Picker.PickPointEnum.PICK_POLYGON);
                    int contador = 0;
                    Point puntoAnterior = new Point();
                    foreach (Point p in pPoints)
                    {
                        if (contador == 0)
                        {
                            puntoAnterior = p;
                        }
                        else
                        {
                            Vector vector = new Vector(p - puntoAnterior);
                            viga.StartPoint = viga.StartPoint + vector;
                            viga.EndPoint = viga.EndPoint + vector;
                            viga.Modify();
                            puntoAnterior = p;                                //   if(Operation.MoveObject(Beam1, Vector1))  
                            myModel.CommitChanges();
                            Thread.Sleep(1000);
                        }
                        contador++;
                    }


                }

                catch (Exception e11)
                {
                    //MessageBox.Show(e11.ToString());
                }





            }

            catch (Exception eea)
            {
                //messeng
            }





        }