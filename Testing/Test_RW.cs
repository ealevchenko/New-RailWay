﻿using EFMT.Concrete;
using EFMT.Entities;
using EFRW.Concrete;
using EFRW.Entities1;
using EFRW.Entities;
using RW;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFRW.Concrete.EFDirectory;

namespace Testing
{
    public class Test_RW
    {
        //EFRailWay ef_rw = new EFRailWay();      
   
        public Test_RW() { 
        
        }

        #region RWCars



        public int RWCars_CreateCarsInternal()
        {
            try
            {
                RWCars rwc = new RWCars();
                //int res = rwc.CreateCarsInternal(3, 3, 77777777, DateTime.Now, 6);
                int res = 0;
                Console.WriteLine("Код выполнения - {0}",res);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }




        }

        public int RWCars_CreateCarOperations()
        {
            try
            {
                RWCars rwc = new RWCars();
                int res = rwc.CreateCarOperations(6,null,null,DateTime.Now,1,1,null,null,null,1);
                Console.WriteLine("Код выполнения - {0}",res);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public int RWCars_CarOperationTransitUZ()
        {
            try
            {
                RWCars rwc = new RWCars();
                EFRW.Entities.CarOperations operation = rwc.GetOperation(61);
                int res = 0;// rwc.SetOperationTransitUZ(operation, DateTime.Now);
                Console.WriteLine("Код выполнения - {0}",res);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }




        }

        //public void EFRailWay_SaveCarsInternal() {


        //    //EFRailWay_SaveDirectory_Cars(777);

        //    CarsInternal new_ci = new CarsInternal()
        //    {
        //        id = 0,
        //        id_sostav = 1,
        //        id_arrival = 2,
        //        num = 777,
        //        dt_uz = DateTime.Now,
        //        dt_inp_amkr = null,
        //        dt_out_amkr = null,
        //        natur_kis_inp = 11,
        //        natur_kis_out = 22,
        //        natur_rw = null,
        //        parent_id = null,
        //        //Directory_Cars = new Directory_Cars()
        //        //{
        //        //    num = 5555,
        //        //    id_type = 0,
        //        //    sap = null,
        //        //    note = null,
        //        //    lifting_capacity = 0,
        //        //    tare = 0,
        //        //    id_country = 0,
        //        //    count_axles = 0,
        //        //    is_output_uz = true,
        //        //}
        //    };
        //    //int res = ef_rw.SaveCarsInternal(new_ci);
        //}



        //#region Directory_Cars
        //public void EFRailWay_CreateSaveEditDeleteDirectory_Cars()
        //{
        //    //Repository
            
        //    //EFRW.Concrete.EFDbContext context = new EFRW.Concrete.EFDbContext();

        //    //Directory_Cars new_car = new Directory_Cars()
        //    //{
        //    //    num = 99999997,
        //    //    id_type = 2,
        //    //    sap = null,
        //    //    note = null,
        //    //    lifting_capacity = 0,
        //    //    tare = 0,
        //    //    id_country = 0,
        //    //    count_axles = 0,
        //    //    is_output_uz = true,
        //    //};
        //    //new_car.user_create = new_car.user_create != null ? new_car.user_create : System.Environment.UserDomainName + @"\" + System.Environment.UserName;
        //    //new_car.dt_create = new_car.dt_create != DateTime.Parse("01.01.0001") ? new_car.dt_create : DateTime.Now;
        //    //Repository.Insert<Directory_Cars>(new_car);
        //    //Directory_Cars res = Repository.Select<Directory_Cars>().Where(c => c.num == 99999997).FirstOrDefault();
        //    ////res.count_axles = 6;
            
            
        //    //Directory_Cars res_upd = context.Directory_Cars.Where(c => c.num == 99999997).FirstOrDefault();
        //    //res_upd.lifting_capacity = 9;
        //    //Repository.Update<Directory_Cars>(res_upd, context);
        //    //Directory_Cars res1 = Repository.Select<Directory_Cars>().Where(c => c.num == 99999997).FirstOrDefault();
            
            
        //    //Directory_Cars res_del = context.Directory_Cars.Where(c => c.num == 99999997).FirstOrDefault();
        //    //res_upd.lifting_capacity = 9;
        //    //Repository.Delete<Directory_Cars>(res_del, context);

        //    EFRW.Concrete.EFDbContext context = new EFRW.Concrete.EFDbContext();


        //    EFDirectoryCars dcars = new EFDirectoryCars(context);
        //    //DirectoryCars dcars = new DirectoryCars();

        //    Directory_Cars new_car = new Directory_Cars()
        //    {
        //        num = 99999997,
        //        id_type = 2,
        //        sap = null,
        //        note = null,
        //        lifting_capacity = 0,
        //        tare = 0,
        //        id_country = 0,
        //        count_axles = 0,
        //        is_output_uz = true,
        //    };

        //    dcars.AddOrUpdate(new_car);
        //    int res1 = dcars.Save();
        //    new_car = dcars.Refresh(new_car);

        //    Directory_Cars new_car1 = dcars.Get(99999997);
        //    new_car1 = dcars.Refresh(new_car1);

        //    new_car1.count_axles = 33;
        //    new_car1.id_type = 1;
        //    dcars.AddOrUpdate(new_car1);
        //    int res2 = dcars.Save();
        //    Directory_Cars new_car2 = dcars.Get(99999997);
        //    dcars.Delete(99999997);
        //    int res3 = dcars.Save();



        //    //EFRailWay ef_rw = new EFRailWay();  
        //    //Directory_Cars new_car = new Directory_Cars()
        //    //{
        //    //    num = 99999990,
        //    //    id_type = 2,
        //    //    sap = null,
        //    //    note = null,
        //    //    lifting_capacity = 0,
        //    //    tare = 0,
        //    //    id_country = 0,
        //    //    count_axles = 0,
        //    //    is_output_uz = true,
        //    //};
        //    //int res = ef_rw.AddDirectory_Cars(new_car);
        //    //Directory_Cars new_car1 = ef_rw.GetDirectory_Cars(99999990);
        //    //new_car1.lifting_capacity = 66;
        //    ////new_car1.Directory_Country = null;
        //    ////new_car1.Directory_OwnerCars = null;
        //    ////new_car1.Directory_TypeCars = null;
        //    ////new_car1.CarsInternal = null;
        //    //int res1 = ef_rw.UpdateDirectory_Cars(new_car1);
        //    //Directory_Cars new_car2 = ef_rw.GetDirectory_Cars(99999990);
        //    //Directory_Cars new_car_del = ef_rw.DeleteDirectory_Cars(99999990);
        //}
        //#endregion

        #endregion


        public void RWTransfer_ArrivalMTToRailway() {
            RWOperation rw_oper = new RWOperation();

            rw_oper.TransferArrivalSostavToRailWay(13083);
            //rw_oper.TransferArrivalSostavToRailWay(7291);
            //rw_oper.TransferArrivalSostavToRailWay(7293);
            //rw_oper.TransferArrivalSostavToRailWay(7295); 

            //rw_oper.TransferArrivalSostavToRailWay(7461);
            //rw_oper.TransferArrivalSostavToRailWay(7462);
            //rw_oper.TransferArrivalSostavToRailWay(7463);
            //rw_oper.TransferArrivalSostavToRailWay(7464);    
       
            //rw_oper.SaveChanges(rw_oper.ExecOperation(2441, new int[] {52736956, 56671670}, rw_oper.OperationSendingStation, new OperationSendingStation(6,20,DateTime.Now,null) ));
            //rw_oper.TransferArrivalSostavToRailWay(7861);
            //rw_oper.TransferArrivalSostavToRailWay(7505);
        }

        public void RWReference_GetReferenceCarsOfNum()
        {
            RWReference rw_ref = new RWReference(true);
            EFMetallurgTrans ef_mt = new EFMetallurgTrans();
            ArrivalCars car = ef_mt.GetArrivalCars(339368);
            ArrivalSostav sost = ef_mt.GetArrivalSostav(car.IDSostav);
            ReferenceCars res = rw_ref.GetReferenceCarsOfNum(car.Num, sost.IDArrival, car.DateOperation, 0, true, true);
        }

        public void RWReference_GetReferenceCars()
        {
            EFRW.Concrete.EFReference ef_ref = new EFRW.Concrete.EFReference();
            RWReference_GetReferenceCarsOfNum();
            //ReferenceCars rc_new = new ReferenceCars() { 
            // num = 63190987, id_type = 0
            //};
            //int res_new = ef_ref.SaveReferenceCars(rc_new);
            ReferenceCars rc = ef_ref.GetReferenceCars(63190987);
            //EntityState resu = ef_ref.efcontext.Entry(ef_ref.efcontext.ReferenceCars).State;
            //EntityState resu = ef_ref.StateReferenceCars;
            //EntityState resu = ef_ref.StateReferenceCars;
            rc.tare = 44;
            rc.change_user = "ww";
            rc.create_user =  "ee";
            int res = ef_ref.SaveReferenceCars(rc);
            ReferenceCars del = ef_ref.DeleteReferenceCars(res);

        }

        public void RWReference_GetReferenceCountry()
        {
            RWReference rw_ref = new RWReference(true);
            //int id = rw_ref.GetIDReferenceCountryOfCodeSNG(22);
            int id = rw_ref.GetIDReferenceCountryOfCodeMT("220");


        }

        public void RWReference_GetReferenceCargo()
        {
            RWReference rw_ref = new RWReference(true);
            int id = rw_ref.GetIDReferenceCargoOfCodeETSNG(141139);


        }

        public void RWOperation_TransferArrivalSostavToRailWay()
        {
            RWOperation rw_oper = new RWOperation();
            EFMetallurgTrans ef_mt = new EFMetallurgTrans();
            ArrivalSostav sost1 = ef_mt.GetArrivalSostav(7393);
            ArrivalSostav sost2 = ef_mt.GetArrivalSostav(7394);
            ArrivalSostav sost3 = ef_mt.GetArrivalSostav(7404);
            //ArrivalCars dbEntry = sost.ArrivalCars.ToList().Find(c => c.Num == 65620254);
            //sost.ArrivalCars.Remove(dbEntry);

            //rw_oper.TransferArrivalSostavToRailWay(sost1);
            //rw_oper.TransferArrivalSostavToRailWay(sost2);
            //rw_oper.TransferArrivalSostavToRailWay(sost3);
        }

        public void EFRailWay_GetCars()
        {
            RWReference rw_ref = new RWReference(true);
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now.AddHours(+2);
            ReferenceCars ref_car = rw_ref.GetReferenceCarsOfNum(1111, 1, DateTime.Now, 0, true, true);
            EFRailWay ef_rw = new EFRailWay();
            //Cars car = new Cars() {
            //    id = 0,
            //    id_arrival = 1,
            //    num = 1111,
            //    id_sostav = 3,
            //    dt_uz = DateTime.Now,
            //    dt_inp_amkr = null,
            //    dt_out_amkr = null,
            //    natur = null,
            //};
            //int id_res = ef_rw.SaveCars(car);
            Cars car1 = ef_rw.GetCars(266);
            car1.dt_uz = DateTime.Now.AddHours(+3);
            //car1.dt_user = dt2;
            int id_res1 = ef_rw.SaveCars(car1);
        }

        public void RWOperation_IsOpenOperation()
        {
            RWOperation rw_oper = new RWOperation();
            List<EFRW.Entities1.CarOperations> list = rw_oper.IsOpenAllOperationOfNum(54645593);
            List<EFRW.Entities1.CarOperations> list1 = rw_oper.IsOpenAllOperationOfNum(0);
        }

        public void RWTransfer_TransferArivalCarsToRailWay()
        {
            RWOperation rw_oper = new RWOperation();
            EFMetallurgTrans ef_mt = new EFMetallurgTrans();
            List<ArrivalSostav> list  = ef_mt.ArrivalSostav.Where(s=>s.ID >=7828).OrderBy(s=>s.ID).ToList();
            foreach (ArrivalSostav s in list) {
                rw_oper.TransferArrivalSostavToRailWay(s.ID);
            }
        }

        public void RWReference_GetShopOfKis()
        {
            RWReference rw_ref = new RWReference(true);
            int? id = rw_ref.GetIDShopOfKis(10,true);
            int? id1 = rw_ref.GetIDShopOfKis(11,true);
        }

        public void RWReference_GetReferenceConsigneeOfKis()
        {
            RWReference rw_ref = new RWReference(true);
            //int id = rw_ref.GetIDReferenceConsigneeOfKis(10, true);
            //int id1 = rw_ref.GetIDReferenceConsigneeOfKis(20, true);
            int id2 = rw_ref.GetIDReferenceConsigneeOfKis(800, true);
        }

        public void RWOperation_CorrectPositionCarsOnWay()
        {
            RWOperation rw_oper = new RWOperation();

            int id2 = rw_oper.SaveChanges(rw_oper.CorrectPositionCarsOnWay(107));
        }

        public void RWOperation_SetWayCorrectPosition()
        {
            RWOperation rw_oper = new RWOperation();
            //EFRailWay ef_rw = new EFRailWay();
            Cars car = rw_oper.GetCars(8194);
            int res = rw_oper.ExecSaveOperation(car, rw_oper.OperationSetWay, new  OperationSetWay(106,DateTime.Now,null,null));
        }

        public void EFRailWay_GetListCars()
        {
            EFRailWay ef_rw = new EFRailWay();
            //List<Cars> list = ef_rw.GetFirstCarsOfNum(52921343).ToList();
            List<CarsHistory> list1 = ef_rw.GetHistoryCarsOfNum(52921343);

        }

        public void RWOperation_DeleteSaveCar()
        {
            RWOperation rw_oper = new RWOperation();
            int res = rw_oper.DeleteSaveCar(1197);
        }

        #region EFRailWay

        public void EFRailWay_query_GetOpenOperationOfNumCar()
        { 
            EFRailWay ef_rw = new EFRailWay();
            DateTime dt_start = DateTime.Now;
            List<EFRW.Entities1.CarOperations> list1 = ef_rw.query_GetOpenOperationOfNumCar(52921079).ToList();
            TimeSpan ts = DateTime.Now - dt_start;
            Console.WriteLine(String.Format("sql -> Количество строк {0}, время выполнения: {1}:{2}:{3}({4})", list1.Count(), ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds));

        }

        public void EFRailWay_GetOpenOperationOfNumCar() { 
            EFRailWay ef_rw = new EFRailWay();
            DateTime dt_start = DateTime.Now;
            List<EFRW.Entities1.CarOperations> list2 = ef_rw.GetOpenOperationOfNumCar(52921079).ToList();
            TimeSpan ts = DateTime.Now - dt_start;
            Console.WriteLine(String.Format("Количество строк {0}, время выполнения: {1}:{2}:{3}({4})", list2.Count(), ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds));

        }
        #endregion

        #region RWOperations

        public void RWOperations_GetOpenOperationOfNumCar()
        {
            RWOperations_old rw_oper = new RWOperations_old();
            EFRW.Entities1.CarOperations res = rw_oper.GetOpenOperation(61362018);
        }

        public void RWOperations_GetLastOperationOfNumCar()
        {
            RWOperations_old rw_oper = new RWOperations_old();
            EFRW.Entities1.CarOperations res = rw_oper.GetLastOperation(61362018);
        }

        public void RWOperations_GetCurrentOperationOfNumCar()
        {
            RWOperations_old rw_oper = new RWOperations_old();
            EFRW.Entities1.CarOperations res = rw_oper.GetCurrentOperation(61362018);
        }

        #endregion

    }
}
