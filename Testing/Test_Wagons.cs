﻿using EFKIS.Concrete;
using EFKIS.Entities;
//using EFRailWay.KIS;
//using EFRailWay.Statics;
//using EFRW.Concrete;
//using EFRW.Entities;
//using EFWagons.Concrete;
//using EFWagons.Entities;
//using EFWagons.KIS;
//using EFWagons.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Test_Wagons
    {
        //PromContent promsostav = new PromContent();
        //VagonsContent vc = new VagonsContent();
        //PromContent pc = new PromContent();
        

        public Test_Wagons() 
        { 
        
        }

        //#region KometaParkState

        //public void Test_EFKometaParkState_KometaParkState()
        //{
        //    EFKometaParkState kps = new EFKometaParkState();
        //    try
        //    {
        //        //List<KometaParkState> list = kps.GetKometaParkState().ToList();
        //        foreach (KometaParkState t in kps.GetKometaParkState())
        //        {
        //            WL(t);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return;
        //    }
        //}

        //public void Test_EFKometaParkState_KometaParkState(int id, DateTime dt)
        //{
        //    EFKometaParkState kps = new EFKometaParkState();
        //    try
        //    {
        //        List<KometaParkState> list = kps.GetKometaParkState(id, dt).ToList();

        //        foreach (KometaParkState t in kps.GetKometaParkState(id, dt))
        //        {
        //            WL(t);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return;
        //    }
        //}

        //public void WL(KometaParkState t)
        //{
        //    if (t == null) { Console.WriteLine(" = Null"); return; }
        //    Console.WriteLine("N_DOC : {0},\t " +
        //        "N_DOC : {1},\t " +
        //        "DATE_DOC : {2},\t " +
        //        "K_STAN : {3},\t " +
        //        "NM_STAN : {4},\t " +
        //        "RAIL : {5},\t " +
        //        "ORDER_RAIL : {6},\t " +
        //        "N_VAG : {7},\t " +
        //        "ID_STRAN : {8},\t " +
        //        "DATE_PR : {9},\t " +
        //        "ID_SOB : {10},\t " +
        //        "NM_SOB : {11},\t " +
        //        "ID_GODN : {12},\t " +
        //        "NM_GODN : {13},\t " +
        //        "ID_GRUZ : {14},\t " +
        //        "NM_GRUZ : {15},\t " +
        //        "ID_MAIL : {16},\t " +
        //        "N_MAIL : {17},\t " +
        //        "DATE_MAIL : {18},\t " +
        //        "ID_MR : {19},\t " +
        //        "TEXT_MR : {20},\t " +
        //        "PRIM : {21},\t " +
        //        "NN : {22},\t " +
        //        "STAN_MAIL : {23},\t " +
        //        "TEXT : {24},\t " +
        //        "ST_OTPR    : {25},\t " +
        //        "PR_GRUZ : {26},\t " +
        //        "TYPE_VAG  : {27},\t " +
        //        "CEH_NAZN  : {28},\t " +
        //        "STATUS  : {29},\t " +
        //        "DT_STATUS : {30},\t " +
        //        "ID_GRUZ2 : {31},\t " +
        //        "NM_GRUZ2 : {32},\t " +
        //        "REM_TUP : {33},\t " +
        //        "PR_V : {34},\t " +
        //        "PR_S : {35},\t " +
        //        "DT_REFRESH : {36},\t " +
        //        "PR_GR : {37},\t " +
        //        "OTCEP : {38},\t " +
        //        "NM_TP : {39},\t ",
        //            t.N_DOC,
        //            t.N_DOC,
        //            t.DATE_DOC,
        //            t.K_STAN,
        //            t.NM_STAN,
        //            t.RAIL,
        //            t.ORDER_RAIL,
        //            t.N_VAG,
        //            t.ID_STRAN,
        //            t.DATE_PR,
        //            t.ID_SOB,
        //            t.NM_SOB,
        //            t.ID_GODN,
        //            t.NM_GODN,
        //            t.ID_GRUZ,
        //            t.NM_GRUZ,
        //            t.ID_MAIL,
        //            t.N_MAIL,
        //            t.DATE_MAIL,
        //            t.ID_MR,
        //            t.TEXT_MR,
        //            t.PRIM,
        //            t.NN,
        //            t.STAN_MAIL,
        //            t.TEXT,
        //            t.ST_OTPR,
        //            t.PR_GRUZ,
        //            t.TYPE_VAG,
        //            t.CEH_NAZN,
        //            t.STATUS,
        //            t.DT_STATUS,
        //            t.ID_GRUZ2,
        //            t.NM_GRUZ2,
        //            t.REM_TUP,
        //            t.PR_V,
        //            t.PR_S,
        //            t.DT_REFRESH,
        //            t.PR_GR,
        //            t.OTCEP,
        //            t.NM_TP
        //            );

        //}
        //#endregion

        public void Test_KometaContent_KometaVagonSob()
        {
            EFWagons kom_con = new EFWagons();
            foreach (KometaVagonSob t in kom_con.GetVagonsSob())
            {
                WL(t);
            }
        }

        public void Test_KometaContent_KometaVagonSob(int num)
        {
            EFWagons kom_con = new EFWagons();
            foreach (KometaVagonSob t in kom_con.GetVagonsSob(num))
            {
                WL(t);
            }
        }

        public void Test_KometaContent_KometaVagonSob(int num, DateTime dt)
        {
            EFWagons kom_con = new EFWagons();
            WL(kom_con.GetVagonsSob(num, dt));
        }

        public void WL(KometaVagonSob t) 
        {
            if (t == null) {
                Console.WriteLine("NULL"); return;
            }   
            Console.WriteLine("N_VAGON: {0},\t SOB: {1},\t DATE_AR: {2},\t DATE_END: {3},\t ROD: {4},\t DATE_REM: {5},\t PRIM: {6},\t CODE: {7}",
                    t.N_VAGON,t.SOB,t.DATE_AR, t.DATE_END, t.ROD,t.DATE_REM, t.PRIM,t.CODE);        
        }

        public void Test_KometaContent_KometaSobstvForNakl()
        {
            EFWagons kom_con = new EFWagons();
            foreach (KometaSobstvForNakl t in kom_con.GetSobstvForNakl())
            {
                WL(t);
            }
        }

        public void Test_KometaContent_KometaSobstvForNakl(int sob)
        {
            EFWagons kom_con = new EFWagons();
            WL(kom_con.GetSobstvForNakl(sob));
        }

        public void WL(KometaSobstvForNakl t)
        {
            if (t == null)
            {
                Console.WriteLine("NULL"); return;
            } 
            Console.WriteLine("NPLAT: {0},\t SOBSTV: {1},\t ABR: {2},\t SOD_PLAT: {3},\t ID: {4},\t ID2: {5}",
                t.NPLAT, t.SOBSTV, t.ABR, t.SOD_PLAT, t.ID, t.ID2);
        }

        //public void Test_KometaContent_GetKometaStrana()
        //{
        //    KometaContent kom_con = new KometaContent();
        //    foreach (KometaStrana t in kom_con.GetKometaStrana())
        //    {
        //        WL(t);
        //    }
        //}

        //public void Test_KometaContent_GetKometaStrana(int kod_stran)
        //{
        //    KometaContent kom_con = new KometaContent();
        //        WL(kom_con.GetKometaStrana(kod_stran));
        //}
        //public void WL(KometaStrana t) 
        //{
        //    if (t == null) { Console.WriteLine(" = Null"); return; }
        //    Console.WriteLine("KOD_STRAN: {0},\t NAME: {1},\t ABREV_STRAN: {2}",
        //            t.KOD_STRAN,t.NAME,t.ABREV_STRAN);        
        //}

        public void Test_PromContent_GetGruzSP()
        {
            EFWagons promsostav = new EFWagons();
            foreach (PromGruzSP t in promsostav.GetGruzSP())
            {
                WL(t);
            }
        }

        public void Test_PromContent_GetGruzSP(int k_gruz)
        {
            EFWagons promsostav = new EFWagons();
            WL(promsostav.GetGruzSP(k_gruz));
        }

        public void Test_PromContent_GetGruzSPToTarGR(int? tar_gr, bool corect)
        {
            EFWagons promsostav = new EFWagons();
            WL(promsostav.GetGruzSPToTarGR(tar_gr, corect));
        }

        public void WL(PromGruzSP t)
        {
            if (t == null) { Console.WriteLine(" = Null"); return; }
            Console.WriteLine("K_GRUZ: {0},\t NAME_GR: {1},\t ABREV_GR: {2},\t GRUP_P: {3},\t NGRUP_P: {4},\t GRUP_O: {5},\t GROUP_OSV: {6},\t NGRUP_O: {7},\t TAR_GR: {8},\t KOD1: {9},\t KOD2: {10},\t K_GR: {11}",
                    t.K_GRUZ, t.NAME_GR, t.ABREV_GR, t.GRUP_P, t.NGRUP_P, t.GRUP_O, t.GROUP_OSV, t.NGRUP_O, t.TAR_GR, t.KOD1, t.KOD2, t.K_GR);
        }

        public void Test_VagonsContent_GetSTPR1GR()
        {

            EFWagons vc = new EFWagons();
            foreach (NumVagStpr1Gr t in vc.GetSTPR1GR())
            {
                WL(t);
            }
        }

        public void Test_VagonsContent_GetSTPR1GR(int kod_gr)
        {
            EFWagons vc = new EFWagons();
            WL(vc.GetSTPR1GR(kod_gr));
        }
        public void WL(NumVagStpr1Gr t)
        {
            if (t == null) { Console.WriteLine(" = Null"); return; }
            Console.WriteLine("KOD_GR: {0},\t GR: {1},\t OLD: {2}",
                    t.KOD_GR, t.GR, t.OLD);
        }

        //public void Test_PromContent_GetNatHist()
        //{
        //    foreach (PromNatHist t in promsostav.GetNatHist())
        //    {
        //        WL(t);
        //    }
        //}

        //public void Test_PromContent_GetNatHist(int natur, int station, int day, int month, int year, int wag)
        //{
        //    WL(promsostav.GetNatHist(natur, station, day, month, year, wag));
        //}

        //public void WL(PromNatHist t)
        //{
        //    //if (t == null) { Console.WriteLine(" = Null"); return; }
        //    //Console.WriteLine("NPP: {0},\t NAME: {1},\t ABREV_STRAN: {2},\t KOD_EUROP: {3},\t KOD_STRAN: {4},\t KOD_OLD: {5}",
        //    //        t.NPP, t.NAME, t.ABREV_STRAN, t.KOD_EUROP, t.KOD_STRAN, t.KOD_OLD);
        //}

        //public void Test_PromContent_GetCex()
        //{
        //    foreach (PromCex t in promsostav.GetCex())
        //    {
        //        WL(t);
        //    }
        //}

        //public void Test_PromContent_GetCex(int k_podr)
        //{
        //    WL(promsostav.GetCex(k_podr));
        //}

        //public void WL(PromCex t) 
        //{
        //    if (t == null) { Console.WriteLine(" = Null"); return; }
        //    Console.WriteLine("K_PODR: {0},\t NAME_P: {1},\t ABREV_P: {2}",
        //            t.K_PODR,t.NAME_P,t.ABREV_P);        
        //}

        //#region NumVagStanStpr1InStDoc & NumVagStanStpr1InStVag

        //public void Test_VagonsContent_GetSTPR1InStDoc()
        //{
        //    foreach (NumVagStpr1InStDoc t in vc.GetSTPR1InStDoc())
        //    {
        //        WL(t);
        //    }
        //}

        //public void Test_VagonsContent_GetSTPR1InStDocOfAmkr()
        //{
        //    foreach (NumVagStpr1InStDoc t in vc.GetSTPR1InStDocOfAmkr())
        //    {
        //        WL(t);
        //    }
        //}

        //public void Test_VagonsContent_GetSTPR1InStDocOfAmkrWhere()
        //{
        //    RulesCopy rc = new RulesCopy();
        //    List<OracleRules> list = rc.GetRulesCopyToOracleRulesOfKis(typeOracleRules.Input);
        //    string wh = "";
        //    DateTime dt = DateTime.Now.AddDays(-2);
        //    foreach (NumVagStpr1InStDoc t in vc.GetSTPR1InStDocOfAmkr(wh.ConvertWhere(list, "a.k_stan", "st_in_st ", "OR")).Where(v=>v.DATE_IN_ST>dt))
        //    {
        //        WL(t);
        //    }
        //}
        //public void WL(NumVagStpr1InStDoc t) 
        //{
        //    if (t == null) { Console.WriteLine(" = Null"); return; }
        //    Console.WriteLine("ID_DOC: {0},\t DATE_IN_ST: {1},\t ST_IN_ST: {2},\t N_PUT_IN_ST: {3},\t NAPR_IN_ST: {4},\t FIO_IN_ST: {5},\t CEX: {6},\t N_POST: {7},\t K_STAN: {8},\t OLD_N_NATUR: {9}",
        //            t.ID_DOC,t.DATE_IN_ST,t.ST_IN_ST,t.N_PUT_IN_ST,t.NAPR_IN_ST,t.FIO_IN_ST,t.CEX,t.N_POST,t.K_STAN, t.OLD_N_NATUR);        
        //}

        //public void Test_VagonsContent_GetSTPR1InStVag()
        //{
        //    foreach (NumVagStpr1InStVag t in vc.GetSTPR1InStVag())
        //    {
        //        WL(t);
        //    }
        //}
        //public void Test_VagonsContent_GetCountSTPR1InStVag()
        //{
        //    Console.WriteLine("57 =  {0}",vc.GetCountSTPR1InStVag(227028));
        //    Console.WriteLine("0 =  {0}",vc.GetCountSTPR1InStVag(0));
        //}
        //public void WL(NumVagStpr1InStVag t) 
        //{
        //    if (t == null) { Console.WriteLine(" = Null"); return; }
        //    Console.WriteLine("ID_DOC: {0},\t N_IN_ST: {1},\t N_VAG: {2},\t STRAN_SOBSTV: {3},\t GODN_IN_ST: {4},\t GR_IN_ST: {5},\t SOBSTV: {6},\t REM_IN_ST: {7},\t ID_VAG: {8},\t ST_NAZN_OUT_ST: {9},\t STRAN_OUT_ST: {10},\t SOBSTV_OLD: {11}",
        //            t.ID_DOC,t.N_IN_ST,t.N_VAG,t.STRAN_SOBSTV,t.GODN_IN_ST,t.GR_IN_ST,t.SOBSTV,t.REM_IN_ST,t.ID_VAG, t.ST_NAZN_OUT_ST, t.STRAN_OUT_ST, t.SOBSTV_OLD);        
        //}

        //#endregion


        //public void Test_PromContent_TestFilter()
        //{
            
        //    List<PromSostav> list = promsostav.GetInputPromSostav(DateTime.Now.AddDays(-1), DateTime.Now).ToList();
        //    List<PromNatHist> list_pnh = promsostav.GetNatHistOfVagonLess(60226420, DateTime.Parse("2017-01-18 05:00:00"), true).ToList();

        //}


        //#region NumVagStanStpr1OutStDoc & NumVagStpr1OutStVag
        ///// <summary>
        ///// Получить все составы по отправке
        ///// </summary>
        //public void Test_VagonsContent_GetSTPR1OutStDoc()
        //{
        //    foreach (NumVagStpr1OutStDoc t in vc.GetSTPR1OutStDoc())
        //    {
        //        WL(t);
        //    }
        //}

        //public void WL(NumVagStpr1OutStDoc t)
        //{
        //    if (t == null) { Console.WriteLine(" = Null"); return; }
        //    Console.WriteLine("ID_DOC: {0},\t DATE_OUT_ST: {1},\t ST_OUT_ST: {2},\t N_PUT_OUT_ST: {3},\t NAPR_OUT_ST: {4},\t FIO_IN_ST: {5},\t CEX: {6},\t K_STAN: {7},\t DATE_ST: {8},\t STATUS: {9},\t NAME_ST: {10}",
        //            t.ID_DOC, t.DATE_OUT_ST, t.ST_OUT_ST, t.N_PUT_OUT_ST, t.NAPR_OUT_ST, t.FIO_IN_ST, t.CEX, t.K_STAN ,t.DATE_ST ,t.STATUS ,t.NAME_ST);
        //}
        ///// <summary>
        ///// Получить все вагоны по отправке
        ///// </summary>
        //public void Test_VagonsContent_GetSTPR1OutStVag()
        //{
        //    foreach (NumVagStpr1OutStVag t in vc.GetSTPR1OutStVag())
        //    {
        //        WL(t);
        //    }
        //}

        //public void WL(NumVagStpr1OutStVag t)
        //{
        //    if (t == null) { Console.WriteLine(" = Null"); return; }
        //    Console.WriteLine("ID_DOC: {0},\t N_OUT_ST: {1},\t GR_OUT_ST: {2},\t SOBSTV: {3},\t REM_IN_ST: {4},\t ID_VAG: {5},\t ST_NAZN_OUT_ST: {6},\t STRAN_OUT_ST: {7},\t SOBSTV_OLD: {8},\t N_TUP_OUT_ST: {9}",
        //            t.ID_DOC, 
        //            t.N_OUT_ST, 
        //            t.GR_OUT_ST, 
        //            t.SOBSTV, 
        //            t.REM_IN_ST, 
        //            t.ID_VAG, 
        //            t.ST_NAZN_OUT_ST, 
        //            t.STRAN_OUT_ST, 
        //            t.SOBSTV_OLD,
        //            t.N_TUP_OUT_ST);
        //}

        //#endregion

        //#region NumVagStpr1Tupik
        ///// <summary>
        ///// Список тупиков
        ///// </summary>
        //public void Test_VagonsContent_GetStpr1Tupik()
        //{
        //    foreach (NumVagStpr1Tupik t in vc.GetStpr1Tupik())
        //    {
        //        WL(t);
        //    }
        //}

        //public void WL(NumVagStpr1Tupik t) 
        //{
        //    if (t == null) { Console.WriteLine(" = Null"); return; }
        //    Console.WriteLine("ID_CEX: {0},\t ID_CEX_TUPIK: {1},\t NAMETUPIK: {2}",
        //            t.ID_CEX,t.ID_CEX_TUPIK,t.NAMETUPIK);        
        //}
        //#endregion

 
        
        //#region NumVagStran
        ///// <summary>
        ///// Список стран
        ///// </summary>
        //public void Test_VagonsContent_GetStran()
        //{
        //    foreach (NumVagStran t in vc.GetStran())
        //    {
        //        WL(t);
        //    }
        //}

        //public void Test_VagonsContent_GetStranOf()
        //{
        //    WL(vc.GetStran(16));
        //    WL(vc.GetStranOfCodeEurope(8405));
        //    WL(vc.GetStranOfCodeStarn(840));
        //}


        //public void WL(NumVagStran t) 
        //{
        //    if (t == null) { Console.WriteLine(" = Null"); return; }
        //    Console.WriteLine("NPP: {0},\t NAME: {1},\t ABREV_STRAN: {2},\t KOD_EUROP: {3},\t KOD_STRAN: {4},\t KOD_OLD: {5}",
        //            t.NPP,t.NAME,t.ABREV_STRAN,t.KOD_EUROP,t.KOD_STRAN,t.KOD_OLD);        
        //}
        //#endregion

        //#region PromSostav
        ///// <summary>
        ///// Список прибывающих и отправляющих вагонов
        ///// </summary>
        ////public void Test_VagonsContent_GetPromSostav()
        ////{
        ////    foreach (PromSostav t in pc.GetPromSostav())
        ////    {
        ////        WL(t);
        ////    }
        ////}

        //public void Test_VagonsContent_GetInputPromSostav()
        //{
        //    foreach (PromSostav t in pc.GetInputPromSostav())
        //    {
        //        WL(t);
        //    }
        //}


        //public void WL(PromSostav t) 
        //{
        //    if (t == null) { Console.WriteLine(" = Null"); return; }
        //    Console.WriteLine("N_NATUR: {0},\t D_DD: {1},\t D_MM: {2},\t D_YY: {3},\t T_HH: {4},\t T_MI: {5},\t K_ST: {6},\t N_PUT: {7},\t NAPR: {8},\t P_OT: {9},\t V_P: {10}",
        //            t.N_NATUR,t.D_DD,t.D_MM,t.D_YY,t.T_HH,t.T_MI,t.K_ST,t.N_PUT,t.NAPR,t.P_OT,t.V_P);        
        //}

        //#endregion


        //public void CopyReferenceWagonsToRailWay()
        //{
        //    KometaContent kcon = new KometaContent();
        //    EFRWReferences rw_ref = new EFRWReferences();

        //    List<IGrouping<int, KometaVagonSob>> group_list = new List<IGrouping<int, KometaVagonSob>>();
        //    group_list = kcon.GetVagonsSob().GroupBy(s => s.N_VAGON).ToList();
        //    foreach (IGrouping<int, KometaVagonSob> group_wag in group_list)
        //    {
        //        string ee = group_wag.Key.ToString();
        //        KometaVagonSob kv = group_wag.Where(v=>v.DATE_AR < DateTime.Now).OrderByDescending(v=>v.DATE_AR).FirstOrDefault();
        //        KometaSobstvForNakl sob = kcon.GetSobstvForNakl(kv!=null ? kv.SOB : 0);
        //        TypeCars tc = rw_ref.GetTypeCarsOfAbr(kv!=null ? kv.ROD : null);
        //        Cars car = new Cars()
        //        {
        //            num = group_wag.Key,
        //            id_type = tc != null ? (int?)tc.id : null,
        //            lifting_capacity = null,
        //            tare = null,
        //            id_country = null,
        //            count_axles = null,
        //            is_output_uz = true,
        //            create = DateTime.Now,
        //            change = null
        //        };
        //        int id_cars = rw_ref.SaveCars(car);
        //        if (id_cars < 0) return;


        //        //if ()
        //        //if (kv != null)
        //        //{
                    
        //        //    //list.Add(new rwCar() { num = kv.N_VAGON, rod = kv.ROD });
        //        //}
        //    }


        //}
    }
}