﻿using EFKIS.Concrete;
using KIS;
using MessageLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Test_KIS
    {
        public Test_KIS() { }


        #region RC

        public void Test_KIS_RW_Transfer_TransferArrivalKISToRailWay()
        {
            KIS_RW_Transfer kis_trans = new KIS_RW_Transfer();
            kis_trans.TransferArrivalKISToRailWay();
        }
        /// <summary>
        /// Поставить на путь
        /// </summary>
        public void Test_KISTransfer_PutCarsToStation()
        {
            KIS_RC_Transfer kis_trans = new KIS_RC_Transfer();
            EFTKIS ef_tkis = new EFTKIS();
            EFKIS.Entities.RCBufferArrivalSostav arr_s = ef_tkis.GetRCBufferArrivalSostav(1940);
            kis_trans.PutCarsToStation(ref arr_s);
        }

        public void Test_KISTransfer_UpdateCarsToStation()
        {
            KIS_RC_Transfer kis_trans = new KIS_RC_Transfer();
            EFTKIS ef_tkis = new EFTKIS();
            EFKIS.Entities.RCBufferArrivalSostav arr_s = ef_tkis.GetRCBufferArrivalSostav(44);
            kis_trans.UpdateCarsToStation(ref arr_s);
        }

        public void Test_KISThread_StartCopyBufferArrivalSostav()
        {
            KISThread kis_t = new KISThread(service.ServicesKIS);
            kis_t.StartCopyBufferArrivalSostav();
            kis_t.StartCopyBufferArrivalSostav();
        }

        public void Test_KISThread_StartTransferArrivalOfKIS()
        {
            KISThread kis_t = new KISThread(service.ServicesKIS);
            kis_t.StartTransferArrivalOfKIS();
        }
        /// <summary>
        /// тест коррекции (удалили натурный лист)
        /// </summary>
        public void Test_KISTransfer_DeleteSostavBufferArrivalSostav()
        {
            KIS_RC_Transfer kis_trans = new KIS_RC_Transfer();
            kis_trans.DeleteSostavRCBufferArrivalSostav(217);
        }

        public void Test_KISTransfer_CloseBufferArrivalSostav()
        {
            KIS_RC_Transfer kis_trans = new KIS_RC_Transfer();
            kis_trans.CloseBufferArrivalSostav();
        }

        public void Test_KISThread_StartCloseBufferArrivalSostav()
        {
            KISThread kis_t = new KISThread(service.ServicesKIS);
            kis_t.StartCloseBufferArrivalSostav();
        }


        /// <summary>
        /// Тест копирования по прибытию
        /// </summary>
        public void Test_KISTransfer_CopyBufferInputSostavOfKIS()
        {
            KIS_RC_Transfer kis_trans = new KIS_RC_Transfer(service.ServicesKIS);
            kis_trans.CopyBufferInputSostavOfKIS(1);
        }

        //public void Test_KISThread_StartCopyBufferInputSostav()
        //{
        //    KISThread kis_t = new KISThread(service.ServicesKIS);
        //    kis_t.StartCopyBufferInputSostav();
        //}


        public void Test_KISTransfer_CopyBufferOutputSostavOfKIS()
        {
            KIS_RC_Transfer kis_trans = new KIS_RC_Transfer(service.ServicesKIS);
            kis_trans.CopyBufferOutputSostavOfKIS(1, false);
        }

        //public void Test_KISThread_StartCopyBufferOutputSostav()
        //{
        //    KISThread kis_t = new KISThread(service.ServicesKIS);
        //    kis_t.StartCopyBufferOutputSostav();
        //}

        public void Test_KISTransfer_TransferArrivalToStation()
        {
            KIS_RC_Transfer kis_trans = new KIS_RC_Transfer();
            EFTKIS ef_tkis = new EFTKIS();
            EFKIS.Entities.RCBufferInputSostav bis = ef_tkis.GetRCBufferInputSostav(2563);
            kis_trans.TransferArrivalToStation(ref bis);
        }

        public void Test_KISTransfer_TransferArrivalOfKISInput()
        {
            KIS_RC_Transfer kis_trans = new KIS_RC_Transfer();
            int res = kis_trans.TransferArrivalOfKISInput();

        }

        public void Test_KISThread_StartTransferInputKIS()
        {
            KISThread kis_t = new KISThread(service.ServicesKIS);
            kis_t.StartTransferInputKIS();
        }

        public void Test_KISThread_StartTransferOutputKIS()
        {
            KISThread kis_t = new KISThread(service.ServicesKIS);
            kis_t.StartTransferOutputKIS();
        }

        public void Test_KISTransfer_TransferOutputArrivalToStation()
        {
            KIS_RC_Transfer kis_trans = new KIS_RC_Transfer();
            EFTKIS ef_tkis = new EFTKIS();
            EFKIS.Entities.RCBufferOutputSostav bos = ef_tkis.GetRCBufferOutputSostav(1112);
            kis_trans.TransferArrivalToStation(ref bos);
        }

        #endregion

        #region TEST RW Перенос принять на АМКР
        public void Test_KISTransfer_SetCarToWayRailWay()
        {
            KIS_RW_Transfer kis_trans = new KIS_RW_Transfer();
            //EFTKIS ef_tkis = new EFTKIS();
            //EFKIS.Entities.BufferOutputSostav bos = ef_tkis.GetBufferOutputSostav(1112);
            //kis_trans.TransferArrivalToStation(ref bos);

            kis_trans.SetCarToWayRailWay(807, 54645593, DateTime.Parse("2018-03-11 18:30:00"), 103);
        }

        public void Test_KIS_RW_Transfer_SetWayRailWayOfKIS()
        {
            KIS_RW_Transfer kis_trans = new KIS_RW_Transfer();
            EFTKIS ef_tkis = new EFTKIS();
            EFKIS.Entities.RWBufferArrivalSostav arr_s = ef_tkis.GetRWBufferArrivalSostav(4595);
            kis_trans.SetWayRailWayOfKIS(ref arr_s);
        }

        public void Test_KISTransfer_UpdWayRailWayOfKIS()
        {
            KIS_RW_Transfer kis_trans = new KIS_RW_Transfer();
            EFTKIS ef_tkis = new EFTKIS();
            EFKIS.Entities.RWBufferArrivalSostav arr_s = ef_tkis.GetRWBufferArrivalSostav(3416);
            kis_trans.UpdWayRailWayOfKIS(ref arr_s);
        }
        #endregion

        #region TEST RW Перенос сдача на УЗ 
        public void Test_KIS_RW_Transfer_CopyBufferSendingSostavOfKIS()
        {
            KIS_RW_Transfer kis_trans = new KIS_RW_Transfer();
            kis_trans.CopyBufferSendingSostavOfKIS(1);
        }

        public void Test_KISThread_StartCopyBufferSendingSostav()
        {
            KISThread kis_t = new KISThread(service.TransferSendingKIS);
            kis_t.StartCopyBufferSendingSostav();
        }

        public void Test_KIS_RW_Transfer_TransferSendingKISToRailWay()
        {
            KIS_RW_Transfer kis_trans = new KIS_RW_Transfer();

            kis_trans.TransferSendingKISToRailWay();
        }

        public void Test_KIS_RW_Transfer_TransferSendingKISToRailWay_SetWayRailWayOfKIS()
        {
            KIS_RW_Transfer kis_trans = new KIS_RW_Transfer();
            EFTKIS ef_tkis = new EFTKIS();
            EFKIS.Entities.RWBufferSendingSostav bss = ef_tkis.GetRWBufferSendingSostav(869);
            int res_put = kis_trans.SetWayRailWayOfKIS(ref bss);

            //int res = kis_trans.SetCarToSendingWayRailWay(bss.natur, 55224646, bss.datetime, 1, 1);

        }

        public void Test_KISThread_StartTransferSendingOfKIS()
        {
            KISThread kis_t = new KISThread(service.TransferSendingKIS);
            kis_t.StartTransferSendingOfKIS();
        }

        public void Test_KIS_RW_Transfer_IsVagonOfSendingNatHistNatur()
        {
            KIS_RW_Transfer kis_trans = new KIS_RW_Transfer();
            bool res = kis_trans.IsVagonOfSendingNatHistNatur(3903, 65888587, new DateTime(2018, 6, 22, 6, 05, 0)); //2018-06-22T06:05:00
        }
        #endregion

        #region TEST RW Перенос по внутреним станциям (по прибытию)

        public void Test_KIS_RW_Transfer_CopyBufferInputSostavOfKIS()
        {
            KIS_RW_Transfer kis_trans = new KIS_RW_Transfer();
            int result = kis_trans.CopyBufferInputSostavOfKIS();
        }

        public void Test_KISThread_StartCopyBufferInputSostav()
        {
            KISThread kis_th = new KISThread(service.TransferInputKIS);
            bool result = kis_th.StartCopyBufferInputSostav();
        }

        public void Test_KIS_RW_Transfer_TransferInputSostavKISToRailway()
        {
            KIS_RW_Transfer kis_trans = new KIS_RW_Transfer();

            kis_trans.TransferInputSostavKISToRailway();
        }

        public void Test_KIS_RW_Transfer_TransferInputSostavKISToRailway_of_RWBufferInputSostav()
        {
            KIS_RW_Transfer kis_trans = new KIS_RW_Transfer();
            EFTKIS ef_tkis = new EFTKIS();
            EFKIS.Entities.RWBufferInputSostav bis = ef_tkis.GetRWBufferInputSostav(9963);
            int result = kis_trans.TransferInputSostavKISToRailway(ref bis);
        }

        #endregion

        #region TEST RW Перенос по внутреним станциям (по отправке)

        public void Test_KIS_RW_Transfer_CopyBufferOutputSostavOfKIS()
        {
            KIS_RW_Transfer kis_trans = new KIS_RW_Transfer();
            int result = kis_trans.CopyBufferOutputSostavOfKIS();
        }

        public void Test_KISThread_StartCopyBufferOutputSostav()
        {
            KISThread kis_th = new KISThread(service.TransferInputKIS);
            bool result = kis_th.StartCopyBufferOutputSostav();
        }

        public void Test_KIS_RW_Transfer_TransferOutputSostavKISToRailway()
        {
            KIS_RW_Transfer kis_trans = new KIS_RW_Transfer();

            kis_trans.TransferOutputSostavKISToRailway();
        }

        public void Test_KIS_RW_Transfer_TransferOutputSostavKISToRailway_of_RWBufferOutputSostav()
        {
            KIS_RW_Transfer kis_trans = new KIS_RW_Transfer();
            EFTKIS ef_tkis = new EFTKIS();
            EFKIS.Entities.RWBufferOutputSostav bos = ef_tkis.GetRWBufferOutputSostav(10455);
            int result = kis_trans.TransferOutputSostavKISToRailway(ref bos);
        }

        #endregion


    }
}
