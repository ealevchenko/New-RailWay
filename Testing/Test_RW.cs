﻿using EFMT.Concrete;
using EFMT.Entities;
using EFRW.Concrete;
using EFRW.Entities;
using RW;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Test_RW
    {
        public Test_RW() { 
        
        }

        public void RWTransfer_ArrivalMTToRailway() {
            RWOperation rw_oper = new RWOperation();

            //rw_oper.TransferArrivalSostavToRailWay(7290);
            //rw_oper.TransferArrivalSostavToRailWay(7291);
            //rw_oper.TransferArrivalSostavToRailWay(7293);
            //rw_oper.TransferArrivalSostavToRailWay(7295); 

            rw_oper.TransferArrivalSostavToRailWay(7461);
            rw_oper.TransferArrivalSostavToRailWay(7462);
            rw_oper.TransferArrivalSostavToRailWay(7463);
             rw_oper.TransferArrivalSostavToRailWay(7464);    
       
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
            List<CarOperations> list = rw_oper.IsOpenAllOperation(54645593);
            List<CarOperations> list1 = rw_oper.IsOpenAllOperation(0);
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

    }
}