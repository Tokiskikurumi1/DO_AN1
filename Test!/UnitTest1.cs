using NUnit.Framework;
using Moq;
using System;
using BLL;
using DAL;
using DAL.Button_form;
using BLL.BLL;


namespace Test_
{
    public class Tests
    {
        private QuanLyNhanVIen _bll;

        [SetUp]
        public void Setup()
        {
            _bll = new QuanLyNhanVIen();
        }

        [Test]
        public void ThemNV_TenRong_TraVeFalse()
        {
            string error;
            var result = _bll.ThemNV(1, "", new DateTime(2000, 1, 1), "0123456789", "Ca 1", "user123", "pass123", "Nhân viên", out error);

            Assert.IsFalse(result);
            Assert.AreEqual("Tên không được để trống!", error);
        }

        [Test]
        public void ThemNV_SDTKhongHopLe_TraVeFalse()
        {
            string error;
            var result = _bll.ThemNV(2, "Nguyen Van B", new DateTime(2000, 1, 1), "sdt123abc", "Ca 1", "user123", "pass123", "Nhân viên", out error);

            Assert.IsFalse(result);
            Assert.AreEqual("Số điện thoại không hợp lệ", error);
        }

        [Test]
        public void ThemNV_TuoiNhoHon18_TraVeFalse()
        {
            string error;
            var result = _bll.ThemNV(3, "Nguyen Van C", DateTime.Now.AddYears(-17), "0123456789", "Ca 1", "user123", "pass123", "Nhân viên", out error);

            Assert.IsFalse(result);
            Assert.AreEqual("Nhân viên chưa đủ 18 tuổi!", error);
        }

        [Test]
        public void ThemNV_IDBiTrung_TraVeFalse()
        {
            string error;
            var result = _bll.ThemNV(4, "Nguyen Van D", new DateTime(2000, 1, 1), "0123456789", "Ca 1", "user123", "pass123", "Nhân viên", out error);

            Assert.IsFalse(result);
            Assert.AreEqual("ID bị trùng!", error);
        }

        [Test]
        public void ThemNV_DuLieuHopLe_TraVeTrue()
        {
            string error;
            var result = _bll.ThemNV(5, "Nguyen Van E", new DateTime(2000, 1, 1), "0123456789", "Ca 1", "user123", "pass123", "Nhân viên", out error);

            Assert.IsTrue(result);
            Assert.AreEqual("", error);
        }
    }
}
