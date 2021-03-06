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
using System.Data;
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

        EFWagons ef_wag = new EFWagons();

        public Test_Wagons()
        {

        }

        #region KometaParkState

        public void Test_EFKometaParkState_KometaParkState()
        {
            EFWagons kps = new EFWagons();
            try
            {
                //List<KometaParkState> list = kps.GetKometaParkState().ToList();
                foreach (KometaParkState t in kps.GetKometaParkState().ToList())
                {
                    WL(t);
                }
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void Test_EFKometaParkState_KometaParkState(DateTime Date)
        {
            EFWagons kps = new EFWagons();

            try
            {
                List<KometaParkState> list = kps.GetKometaParkState(Date).ToList();
                foreach (KometaParkState t in list)
                {
                    WL(t);
                }
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void Test_EFKometaParkState_KometaParkStateToStation(DateTime Date)
        {
            EFWagons kps = new EFWagons();

            try
            {
                List<IGrouping<string, KometaParkState>> list = kps.GetKometaParkStateToStation(Date).ToList();
                foreach (IGrouping<string, KometaParkState> tg in list)
                {
                    foreach (KometaParkState t in tg)
                    {
                        WL(t);
                    }

                }
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void Test_EFKometaParkState_KometaParkState(DateTime Date, int id_station)
        {
            EFWagons kps = new EFWagons();
            try
            {
                List<KometaParkState> list = kps.GetKometaParkState(Date, id_station).ToList();
                foreach (KometaParkState t in list)
                {
                    WL(t);
                }
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void Test_EFKometaParkState_KometaParkStateToWay(DateTime Date, int id_station)
        {
            EFWagons kps = new EFWagons();
            try
            {
                List<IGrouping<string, KometaParkState>> list = kps.GetKometaParkStateToWay(Date, id_station).ToList();
                foreach (IGrouping<string, KometaParkState> tg in list)
                {
                    foreach (KometaParkState t in tg)
                    {
                        WL(t);
                    }

                }
            }
            catch (Exception e)
            {
                return;
            }
        }

        //public void Test_EFKometaParkState_KometaParkState(int id, DateTime dt)
        //{
        //    EFWagons kps = new EFWagons();
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

        public void WL(KometaParkState t)
        {
            if (t == null) { Console.WriteLine(" = Null"); return; }
            Console.WriteLine("N_DOC : {0},\t " +
                "N_DOC : {1},\t " +
                "DATE_DOC : {2},\t " +
                "K_STAN : {3},\t " +
                "NM_STAN : {4},\t " +
                "RAIL : {5},\t " +
                "ORDER_RAIL : {6},\t " +
                "N_VAG : {7},\t " +
                "ID_STRAN : {8},\t " +
                "DATE_PR : {9},\t " +
                "ID_SOB : {10},\t " +
                "NM_SOB : {11},\t " +
                "ID_GODN : {12},\t " +
                "NM_GODN : {13},\t " +
                "ID_GRUZ : {14},\t " +
                "NM_GRUZ : {15},\t " +
                "ID_MAIL : {16},\t " +
                "N_MAIL : {17},\t " +
                "DATE_MAIL : {18},\t " +
                "ID_MR : {19},\t " +
                "TEXT_MR : {20},\t " +
                "PRIM : {21},\t " +
                "NN : {22},\t " +
                "STAN_MAIL : {23},\t " +
                "TEXT : {24},\t " +
                "ST_OTPR    : {25},\t " +
                "PR_GRUZ : {26},\t " +
                "TYPE_VAG  : {27},\t " +
                "CEH_NAZN  : {28},\t " +
                "STATUS  : {29},\t " +
                "DT_STATUS : {30},\t " +
                "ID_GRUZ2 : {31},\t " +
                "NM_GRUZ2 : {32},\t " +
                "REM_TUP : {33},\t " +
                "PR_V : {34},\t " +
                "PR_S : {35},\t " +
                "DT_REFRESH : {36},\t " +
                "PR_GR : {37},\t " +
                "OTCEP : {38},\t " +
                "NM_TP : {39},\t ",
                    t.N_DOC,
                    t.N_DOC,
                    t.DATE_DOC,
                    t.K_STAN,
                    t.NM_STAN,
                    t.RAIL,
                    t.ORDER_RAIL,
                    t.N_VAG,
                    t.ID_STRAN,
                    t.DATE_PR,
                    t.ID_SOB,
                    t.NM_SOB,
                    t.ID_GODN,
                    t.NM_GODN,
                    t.ID_GRUZ,
                    t.NM_GRUZ,
                    t.ID_MAIL,
                    t.N_MAIL,
                    t.DATE_MAIL,
                    t.ID_MR,
                    t.TEXT_MR,
                    t.PRIM,
                    t.NN,
                    t.STAN_MAIL,
                    t.TEXT,
                    t.ST_OTPR,
                    t.PR_GRUZ,
                    t.TYPE_VAG,
                    t.CEH_NAZN,
                    t.STATUS,
                    t.DT_STATUS,
                    t.ID_GRUZ2,
                    t.NM_GRUZ2,
                    t.REM_TUP,
                    t.PR_V,
                    t.PR_S,
                    t.DT_REFRESH,
                    t.PR_GR,
                    t.OTCEP,
                    t.NM_TP
                    );

        }
        #endregion

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
            if (t == null)
            {
                Console.WriteLine("NULL"); return;
            }
            Console.WriteLine("N_VAGON: {0},\t SOB: {1},\t DATE_AR: {2},\t DATE_END: {3},\t ROD: {4},\t DATE_REM: {5},\t PRIM: {6},\t CODE: {7}",
                    t.N_VAGON, t.SOB, t.DATE_AR, t.DATE_END, t.ROD, t.DATE_REM, t.PRIM, t.CODE);
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
        //public void Test_PROM_GetPromNatHist()
        //{
        //    EFWagons ef_wag = new EFWagons();
        //    List<PromNatHist> list = ef_wag.GetPromNatHist().Where(n => n.N_VAG == 54604095).ToList();
        //    foreach (PromNatHist t in list)
        //    {
        //        WL(t);
        //    }
        //}

        //public void WL(PromNatHist t)
        //{
        //    if (t == null) { Console.WriteLine(" = Null"); return; }

        //    Console.WriteLine("N_VAG: {0},\t NPP: {1},\t GODN: {2},\t K_ST: {3},\t KOD_STRAN: {4},\t N_NATUR: {5},\t ST_OTPR: {6}",
        //            t.N_VAG, t.NPP, t.GODN, t.K_ST, t.KOD_STRAN, t.N_NATUR, t.ST_OTPR);
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

        #region PromSostav
        /// <summary>
        /// Список прибывающих и отправляющих вагонов
        /// </summary>
        //public void Test_VagonsContent_GetPromSostav()
        //{
        //    foreach (PromSostav t in pc.GetPromSostav())
        //    {
        //        WL(t);
        //    }
        //}

        //public void Test_VagonsContent_GetInputPromSostav()
        //{
        //    foreach (PromSostav t in pc.GetInputPromSostav())
        //    {
        //        WL(t);
        //    }
        //}
        public void Test_PROM_GetPromSostav()
        {
            try
            {
                EFWagons ef_wag = new EFWagons();
                //List<PromSostav> list = ef_wag.GetPromSostav().ToList();
                //List<sostav_kis> list_kis = ef_wag.GetPromSostav()
                //    .ToList().Select(l => new sostav_kis
                //    {
                //        N_NATUR = l.N_NATUR,
                //        D_PR_DD = l.D_PR_DD,
                //        D_DD = l.D_DD,
                //        D_PR_MM = l.D_PR_MM,
                //        D_MM = l.D_MM,
                //        D_PR_YY = l.D_PR_YY,
                //        D_YY = l.D_YY,
                //        T_PR_HH = l.T_PR_HH,
                //        T_HH = l.T_HH,
                //        T_PR_MI = l.T_PR_MI,
                //        T_MI = l.T_MI,
                //        K_ST = l.K_ST,
                //        N_PUT = l.N_PUT,
                //        NAPR = l.NAPR,
                //        P_OT = l.P_OT,
                //        V_P = l.V_P,
                //        K_ST_OTPR = l.K_ST_OTPR,
                //        K_ST_PR = l.K_ST_PR,
                //        N_VED_PR = l.N_VED_PR,
                //        N_SOST_OT = l.N_SOST_OT,
                //        N_SOST_PR = l.N_SOST_PR,
                //        //DT_PR_Key = l.DT_PR_Key,
                //    }).ToList();

                //List<sostav_kis> list_kis = new List<sostav_kis>();
                //foreach (PromSostav ps in ef_wag.GetPromSostav().OrderBy(s=>s.D_PR_YY).OrderBy(s=>s.D_PR_MM).OrderBy(s=>s.D_PR_DD).ToList()) { 
                //    list_kis.Add(new sostav_kis
                //    {
                //        N_NATUR = ps.N_NATUR,
                //        D_PR_DD = ps.D_PR_DD,
                //        D_DD = ps.D_DD,
                //        D_PR_MM = ps.D_PR_MM,
                //        D_MM = ps.D_MM,
                //        D_PR_YY = ps.D_PR_YY,
                //        D_YY = ps.D_YY,
                //        T_PR_HH = ps.T_PR_HH,
                //        T_HH = ps.T_HH,
                //        T_PR_MI = ps.T_PR_MI,
                //        T_MI = ps.T_MI,
                //        K_ST = ps.K_ST,
                //        N_PUT = ps.N_PUT,
                //        NAPR = ps.NAPR,
                //        P_OT = ps.P_OT,
                //        V_P = ps.V_P,
                //        K_ST_OTPR = ps.K_ST_OTPR,
                //        K_ST_PR = ps.K_ST_PR,
                //        N_VED_PR = ps.N_VED_PR,
                //        N_SOST_OT = ps.N_SOST_OT,
                //        N_SOST_PR = ps.N_SOST_PR,
                //        //DT_PR_Key = l.DT_PR_Key,
                //    });
                //}

                //List<Prom_Sostav> list_ps = ef_wag.GetProm_Sostav().ToList();
                //List<Prom_Sostav> list_natur = list_ps.Where(l => l.N_NATUR == 3850).ToList();

                //List<Prom_Sostav> list_ps1 = ef_wag.GetProm_Sostav().ToList();
                //List<Prom_Sostav> list_natur1 = list_ps1.Where(l => l.N_NATUR == 3850).ToList();
                //List<Prom_Sostav> list2 = list_ps1.Where(l => l.DT >= new DateTime(2018, 6, 20, 0, 0, 0) & l.DT <= new DateTime(2018, 6, 20, 23, 59, 59)).ToList();

                //List<Prom_Sostav> list = ef_wag.GetProm_Sostav().ToList();
                //List<Prom_Sostav> list1 = ef_wag.GetProm_Sostav(new DateTime(2018, 6, 20, 0, 0, 0), new DateTime(2018, 6, 20, 23, 59, 59)).ToList();

                //List<Prom_SostavAndCount> list_psc = ef_wag.GetProm_SostavAndCount().ToList();
                List<Prom_SostavAndCount> list_psc1 = ef_wag.GetProm_SostavAndCount(new DateTime(2018, 6, 20, 0, 0, 0), new DateTime(2018, 6, 20, 23, 59, 59)).ToList();

                //List<Prom_Sostav> list_input = ef_wag.GetInputProm_Sostav(new DateTime(2018, 6, 20, 0, 0, 0), new DateTime(2018, 6, 20, 23, 59, 59), false).ToList();
                //List<Prom_Sostav> list_output = ef_wag.GetOutputProm_Sostav(new DateTime(2018, 6, 20, 0, 0, 0), new DateTime(2018, 6, 20, 23, 59, 59), true).ToList();

                //List<PromSostav> list_s = ef_wag.GetPromSostav().ToList();
                //List<PromSostav> list = list_s.Where(l => l.DT_PR_Key >= new DateTime(2018, 6, 1, 0, 0, 0) & l.DT_PR_Key <= new DateTime(2018, 6, 20, 23, 59, 59)).ToList();
                //List<sostav_kis> list1 = list_kis.Where(l => l.N_NATUR == 3850).ToList();
                //List<PromSostav> list2 = list_s.Where(l => l.DT==null).ToList();
                //List<PromSostav> list = ef_wag.GetPromSostav(new DateTime(2018, 6, 20, 0, 0, 0), new DateTime(2018, 6, 20, 23, 59, 59)).ToList();
                //foreach (PromSostav t in list)
                //{
                //    WL(t);
                //}
            }
            catch (Exception e)
            {

                return;
            }
        }

        public void Test_PROM_GetInputPromSostav()
        {
            EFWagons ef_wag = new EFWagons();
            //List<PromSostav> list = ef_wag.GetInputPromSostav(DateTime.Now.AddDays(-10),DateTime.Now, false).ToList();
            //List<PromSostav> list = ef_wag.GetInputPromSostav().ToList();
            //foreach (PromSostav t in ef_wag.GetInputPromSostav())
            //{
            //    WL(t);
            //}
        }

        public void Test_PROM_GetOutputPromSostav()
        {
            EFWagons ef_wag = new EFWagons();
            //List<PromSostav> list = ef_wag.GetOutputPromSostav(DateTime.Now.AddDays(-10), DateTime.Now, false).ToList();
            //List<PromSostav> list = ef_wag.GetOutputPromSostav().ToList();
            //foreach (PromSostav t in ef_wag.GetOutputPromSostav())
            //{
            //    WL(t);
            //}
        }

        //public void WL(PromSostav t)
        //{
        //    if (t == null) { Console.WriteLine(" = Null"); return; }
        //    Console.WriteLine("N_NATUR: {0},\t D_DD: {1},\t D_MM: {2},\t D_YY: {3},\t T_HH: {4},\t T_MI: {5},\t K_ST: {6},\t N_PUT: {7},\t NAPR: {8},\t P_OT: {9},\t V_P: {10}",
        //            t.N_NATUR, t.D_DD, t.D_MM, t.D_YY, t.T_HH, t.T_MI, t.K_ST, t.N_PUT, t.NAPR, t.P_OT, t.V_P);
        //}

        //public void Test_PROM_GetProm_Vagon()
        //{
        //    EFWagons ef_wag = new EFWagons();
        //    List<Prom_Vagon> list = ef_wag.GetProm_Vagon().ToList();
        //    //List<Prom_Sostav> list_input = ef_wag.GetInputProm_Sostav(new DateTime(2018, 6, 20, 0, 0, 0), new DateTime(2018, 6, 20, 23, 59, 59), false).ToList();
        //    //List<Prom_Sostav> list_output = ef_wag.GetOutputProm_Sostav(new DateTime(2018, 6, 20, 0, 0, 0), new DateTime(2018, 6, 20, 23, 59, 59), true).ToList();

        //}

        //public void Test_PROM_GetProm_NatHist()
        //{
        //    EFWagons ef_wag = new EFWagons();

        //    List<Prom_NatHist> list = ef_wag.GetProm_NatHist().ToList();
        //    //List<Prom_Sostav> list_input = ef_wag.GetInputProm_Sostav(new DateTime(2018, 6, 20, 0, 0, 0), new DateTime(2018, 6, 20, 23, 59, 59), false).ToList();
        //    //List<Prom_Sostav> list_output = ef_wag.GetOutputProm_Sostav(new DateTime(2018, 6, 20, 0, 0, 0), new DateTime(2018, 6, 20, 23, 59, 59), true).ToList();

        //}

        public void Test_PROM_GetProm_SostavAndCount()
        {
            try
            {
                EFWagons ef_wag = new EFWagons();

                //List<Prom_SostavAndCount> list_psc = ef_wag.GetProm_SostavAndCount().ToList();
                //List<Prom_SostavAndCount> list_psc1 = ef_wag.GetProm_SostavAndCount(new DateTime(2018, 6, 20, 0, 0, 0), new DateTime(2018, 6, 20, 23, 59, 59)).ToList();
                List<Prom_SostavAndCount> list_psc2 = ef_wag.GetProm_SostavAndCount(1234, null, null, null, null, null).ToList();
            }
            catch (Exception e)
            {

                return;
            }
        }

        public void Test_PROM_GetProm_VagonAndSostav()
        {
            try
            {
                EFWagons ef_wag = new EFWagons();

                //List<Prom_VagonAndSostav> list_vas = ef_wag.GetProm_VagonAndSostav().ToList();
                List<Prom_VagonAndSostav> list_vas1 = ef_wag.GetProm_VagonAndSostav(94814431).ToList();
                //List<Prom_SostavAndCount> list_psc1 = ef_wag.GetProm_SostavAndCount(new DateTime(2018, 6, 20, 0, 0, 0), new DateTime(2018, 6, 20, 23, 59, 59)).ToList();
                //List<Prom_SostavAndCount> list_psc2 = ef_wag.GetProm_SostavAndCount(1234,null,null,null,null,null).ToList();
            }
            catch (Exception e)
            {

                return;
            }
        }

        public void Test_PROM_GetProm_NatHistAndSostav()
        {
            try
            {
                EFWagons ef_wag = new EFWagons();

                //List<Prom_NatHistAndSostav> list_vas = ef_wag.GetProm_VagonAndSostav().ToList();
                List<Prom_NatHistAndSostav> list_vas1 = ef_wag.GetProm_NatHistAndSostav(62125950).ToList();
                //List<Prom_NatHistAndSostav> list_psc1 = ef_wag.GetProm_SostavAndCount(new DateTime(2018, 6, 20, 0, 0, 0), new DateTime(2018, 6, 20, 23, 59, 59)).ToList();
                //List<Prom_NatHistAndSostav> list_psc2 = ef_wag.GetProm_SostavAndCount(1234,null,null,null,null,null).ToList();
            }
            catch (Exception e)
            {

                return;
            }
        }
        #endregion

        #region PromNatHist

        //public void Test_PROM_GetNatHistOfVagonMoreSD()
        //{
        //    try
        //    {
        //        //EFWagons ef_wag1 = new EFWagons();
        //        DateTime start = DateTime.Now;
        //        List<PromNatHist> list = ef_wag.GetNatHistOfVagonMoreSD(52921004, new DateTime(2017, 6, 19, 22, 50, 0), true).ToList();
        //        DateTime stop = DateTime.Now;
        //        TimeSpan diff1 = stop.Subtract(start);
        //        Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);
        //    }
        //    catch (Exception e)
        //    {

        //        return;
        //    }
        //}

        public void Test_PROM_GetProm_NatHistOfVagonMoreSD()
        {
            try
            {
                //EFWagons ef_wag2 = new EFWagons();
                DateTime start = DateTime.Now;
                List<Prom_NatHist> list1 = ef_wag.GetSendingProm_NatHistOfVagonMore(52921004, new DateTime(2017, 6, 19, 22, 50, 0), true).ToList();
                DateTime stop = DateTime.Now;
                TimeSpan diff1 = stop.Subtract(start);
                Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);

            }
            catch (Exception e)
            {

                return;
            }
        }

        public void Test_PROM_GetProm_NatHistOfVagonMoreEqualSD()
        {
            try
            {
                //EFWagons ef_wag2 = new EFWagons();
                DateTime start = DateTime.Now;
                List<Prom_NatHist> list1 = ef_wag.GetSendingProm_NatHistOfVagonMoreEqual(52921004, new DateTime(2017, 6, 19, 22, 50, 0), true).ToList();
                DateTime stop = DateTime.Now;
                TimeSpan diff1 = stop.Subtract(start);
                Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);

            }
            catch (Exception e)
            {

                return;
            }
        }

        //public void Test_PROM_GetNatHistOfVagonLessPR()
        //{
        //    try
        //    {
        //        //EFWagons ef_wag1 = new EFWagons();
        //        DateTime start = DateTime.Now;
        //        List<PromNatHist> list = ef_wag.GetNatHistOfVagonLessPR(52921004, new DateTime(2017, 6, 19, 22, 50, 0), true).ToList();
        //        DateTime stop = DateTime.Now;
        //        TimeSpan diff1 = stop.Subtract(start);
        //        Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);
        //    }
        //    catch (Exception e)
        //    {

        //        return;
        //    }
        //}

        public void Test_PROM_GetProm_NatHistOfVagonLessPR()
        {
            try
            {
                //EFWagons ef_wag2 = new EFWagons();
                DateTime start = DateTime.Now;
                List<Prom_NatHist> list1 = ef_wag.GetArrivalProm_NatHistOfVagonLess(52921004, new DateTime(2017, 6, 19, 22, 50, 0), true).ToList();
                DateTime stop = DateTime.Now;
                TimeSpan diff1 = stop.Subtract(start);
                Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);

            }
            catch (Exception e)
            {

                return;
            }
        }

        //public void Test_PROM_GetNatHistOfVagonLessEqualPR()
        //{
        //    try
        //    {
        //        //EFWagons ef_wag1 = new EFWagons();
        //        DateTime start = DateTime.Now;
        //        List<PromNatHist> list = ef_wag.GetNatHistOfVagonLessEqualPR(52921004, new DateTime(2017, 6, 19, 22, 50, 0), true).ToList();
        //        DateTime stop = DateTime.Now;
        //        TimeSpan diff1 = stop.Subtract(start);
        //        Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);
        //    }
        //    catch (Exception e)
        //    {

        //        return;
        //    }
        //}

        public void Test_PROM_GetProm_NatHistOfVagonLessEqualPR()
        {
            try
            {
                //EFWagons ef_wag2 = new EFWagons();
                DateTime start = DateTime.Now;
                List<Prom_NatHist> list1 = ef_wag.GetArrivalProm_NatHistOfVagonLessEqual(52921004, new DateTime(2017, 6, 19, 22, 50, 0), true).ToList();
                DateTime stop = DateTime.Now;
                TimeSpan diff1 = stop.Subtract(start);
                Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);

            }
            catch (Exception e)
            {

                return;
            }
        }

        //public void Test_PROM_GetNatHistPR()
        //{
        //    try
        //    {
                
        //        DateTime start = DateTime.Now;
        //        List<PromNatHist> list = ef_wag.GetNatHistPR(3469, 1, 6, 6, 2018, true).ToList();
        //        DateTime stop = DateTime.Now;
        //        TimeSpan diff1 = stop.Subtract(start);
        //        Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);                
        //    }
        //    catch (Exception e)
        //    {

        //        return;
        //    }
        //}

        public void Test_PROM_GetArrivalProm_NatHistOfNaturStationDate()
        {
            try
            {
                
                DateTime start = DateTime.Now;               
                List<Prom_NatHist> list = ef_wag.GetArrivalProm_NatHistOfNaturStationDate(3469, 1, 6, 6, 2018, true).ToList();
                DateTime stop = DateTime.Now;
                TimeSpan diff1 = stop.Subtract(start);
                Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);                
            }
            catch (Exception e)
            {

                return;
            }
        }

        public void Test_PROM_GetArrivalProm_VagonOfNaturStationDate()
        {
            try
            {
                
                DateTime start = DateTime.Now;
                List<Prom_Vagon> list = ef_wag.GetArrivalProm_VagonOfNaturStationDate(3469, 1, 6, 6, 2018, false).ToList();
                DateTime stop = DateTime.Now;
                TimeSpan diff1 = stop.Subtract(start);
                Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);                
            }
            catch (Exception e)
            {

                return;
            }
        }



        public void Test_PROM_GetArrivalProm_VagonOfNaturStationDateNum()
        {
            try
            {
                
                DateTime start = DateTime.Now;
                Prom_Vagon pv = ef_wag.GetArrivalProm_VagonOfNaturNumStationDate(3469, 62975255, 1, 6, 6, 2018);
                DateTime stop = DateTime.Now;
                TimeSpan diff1 = stop.Subtract(start);
                Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);                
            }
            catch (Exception e)
            {

                return;
            }
        }

        public void Test_PROM_GetSendingProm_NatHistOfNaturDate()
        {
            try
            {
                
                DateTime start = DateTime.Now;
                List<Prom_NatHist> list = ef_wag.GetSendingProm_NatHistOfNaturDate(4198, 3, 7, 2018, true).ToList();
                DateTime stop = DateTime.Now;
                TimeSpan diff1 = stop.Subtract(start);
                Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);                
            }
            catch (Exception e)
            {

                return;
            }
        }

        public void Test_PROM_GetSendingProm_NatHistOfNaturDateTime()
        {
            try
            {
                
                DateTime start = DateTime.Now;
                List<Prom_NatHist> list = ef_wag.GetSendingProm_NatHistOfNaturDateTime(4198, 3, 7, 2018,14,0, true).ToList();
                DateTime stop = DateTime.Now;
                TimeSpan diff1 = stop.Subtract(start);
                Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);                
            }
            catch (Exception e)
            {

                return;
            }
        }

        public void Test_PROM_GetArrivalProm_NatHistOfNaturDateTime()
        {
            try
            {
                
                DateTime start = DateTime.Now;
                List<Prom_NatHist> list = ef_wag.GetArrivalProm_NatHistOfNaturDateTime(3469, 6, 6, 2018, 12, 25, null).ToList();
                DateTime stop = DateTime.Now;
                TimeSpan diff1 = stop.Subtract(start);
                Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);                
            }
            catch (Exception e)
            {

                return;
            }
        }

        public void Test_PROM_GetSendingProm_NatHistOfNaturNumDateTime()
        {
            try
            {
                
                DateTime start = DateTime.Now;
                Prom_NatHist pnh = ef_wag.GetSendingProm_NatHistOfNaturNumDateTime(4198, 94814431, 3, 7, 2018, 14, 0);
                DateTime stop = DateTime.Now;
                TimeSpan diff1 = stop.Subtract(start);
                Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);                
            }
            catch (Exception e)
            {

                return;
            }
        }

        public void Test_PROM_GetSendingProm_NatHistOfNumDateTime()
        {
            try
            {
                
                DateTime start = DateTime.Now;
                Prom_NatHist pnh = ef_wag.GetSendingProm_NatHistOfNumDateTime(94814431, 3, 7, 2018, 14, 0);
                DateTime stop = DateTime.Now;
                TimeSpan diff1 = stop.Subtract(start);
                Console.WriteLine("Время выполнения млc - {0}", diff1.TotalMilliseconds);                
            }
            catch (Exception e)
            {

                return;
            }
        }

        #endregion

        #region NUM_VAG

        public void Test_NUM_VAG_GetNumVag_Stpr1OutStDoc()
        {
            try
            {
                EFWagons ef_wag = new EFWagons();
                List<NumVag_Stpr1OutStDoc> list_doc1 = ef_wag.GetNumVag_Stpr1OutStDoc().ToList();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void Test_NUM_VAG_GetNumVag_Stpr1OutStDocOfStartStop()
        {
            try
            {
                EFWagons ef_wag = new EFWagons();
                DateTime start = new DateTime(2018, 9, 24, 0, 0, 0);
                DateTime stop = new DateTime(2018, 9, 25, 0, 0, 0);
                List<NumVag_Stpr1OutStDoc> list_doc1 = ef_wag.GetNumVag_Stpr1OutStDoc(start,stop).ToList();
                List<NumVag_Stpr1OutStDoc> list_doc2 = ef_wag.GetNumVag_Stpr1OutStDoc(start,stop, false).ToList();
                List<NumVag_Stpr1OutStDoc> list_doc3 = ef_wag.GetNumVag_Stpr1OutStDoc(start,stop, true).ToList();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void Test_NUM_VAG_GetNumVag_Stpr1OutStVag()
        {
            try
            {
                EFWagons ef_wag = new EFWagons();
                List<NumVag_Stpr1OutStVag> list_vas1 = ef_wag.GetNumVag_Stpr1OutStVag().ToList();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void Test_NUM_VAG_GetNumVag_Stpr1OutStVagOfNatur()
        {
            try
            {
                EFWagons ef_wag = new EFWagons();
                List<NumVag_Stpr1OutStVag> list_vas1 = ef_wag.GetNumVag_Stpr1OutStVag(126130,false).ToList();
                List<NumVag_Stpr1OutStVag> list_vas2 = ef_wag.GetNumVag_Stpr1OutStVag(126130,true).ToList();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void Test_NUM_VAG_GetNumVag_Stpr1InStDoc()
        {
            try
            {
                EFWagons ef_wag = new EFWagons();
                List<NumVag_Stpr1InStDoc> list_doc1 = ef_wag.GetNumVag_Stpr1InStDoc().ToList();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void Test_NUM_VAG_GetNumVag_Stpr1InStDocOfStartStop()
        {
            try
            {
                EFWagons ef_wag = new EFWagons();
                DateTime start = new DateTime(2018, 9, 24, 0, 0, 0);
                DateTime stop = new DateTime(2018, 9, 25, 0, 0, 0);
                List<NumVag_Stpr1InStDoc> list_doc1 = ef_wag.GetNumVag_Stpr1InStDoc(start, stop).ToList();
                List<NumVag_Stpr1InStDoc> list_doc2 = ef_wag.GetNumVag_Stpr1InStDoc(start, stop, false).ToList();
                List<NumVag_Stpr1InStDoc> list_doc3 = ef_wag.GetNumVag_Stpr1InStDoc(start, stop, true).ToList();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void Test_NUM_VAG_GetNumVag_Stpr1InStVag()
        {
            try
            {
                EFWagons ef_wag = new EFWagons();
                List<NumVag_Stpr1InStVag> list_vas1 = ef_wag.GetNumVag_Stpr1InStVag().ToList();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void Test_NUM_VAG_GetNumVag_Stpr1InStVagOfNatur()
        {
            try
            {
                EFWagons ef_wag = new EFWagons();
                List<NumVag_Stpr1InStVag> list_vas1 = ef_wag.GetNumVag_Stpr1InStVag(280557, false).ToList();
                List<NumVag_Stpr1InStVag> list_vas2 = ef_wag.GetNumVag_Stpr1InStVag(280557, true).ToList();
            }
            catch (Exception e)
            {
                return;
            }
        }

        #endregion

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
