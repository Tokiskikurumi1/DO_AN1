using Moq;
using NUnit.Framework;
using BLL.BLL;
using DAL.Button_form;
using System.Data;

namespace BLL.Tests
{
    [TestFixture]
    public class QuanLyMenuTests
    {
        private Mock<IQuanLyMenuDal> mockQuanLyMenu;
        private QuanLyMenu quanLyMenu;

        [SetUp]
        public void Setup()
        {
            // Create mock instance of IQuanLyMenuDal
            mockQuanLyMenu = new Mock<IQuanLyMenuDal>();
            // Inject the mock into the QuanLyMenu class
            quanLyMenu = new QuanLyMenu(mockQuanLyMenu.Object);
        }

        //TEST LẤY DANH MỤC SẢN PHẨM

        [Test]
        public void TestLoadDM_Travedanhmuc()
        {
            // Arrange
            char maDM = 'A';
            var expectedDataTable = new DataTable();
            mockQuanLyMenu.Setup(m => m.dboloadDM(maDM)).Returns(expectedDataTable);

            // Act
            var result = quanLyMenu.loadDM(maDM);

            // Assert
            Assert.AreEqual(expectedDataTable, result);
        }

        //TEST THÊM MON 

        [Test]
        public void TestThemMonAn_TraVeTrue_GiaTriNhapHopLe()
        {
            // Arrange
            string errorMessage;
            int id = 1;
            string name = "Burger";
            int gia = 100;
            string maDanhMuc = "A01";

            mockQuanLyMenu.Setup(m => m.CheckIdExists(id)).Returns(false);
            mockQuanLyMenu.Setup(m => m.ThemMon(id, name, gia, maDanhMuc)).Returns(true);

            // Act
            var result = quanLyMenu.ThemMonAn(id, name, gia, maDanhMuc, out errorMessage);

            // Assert
            Assert.IsTrue(result);
            Assert.IsEmpty(errorMessage);
        }

        // THÊM MÓN KHÔNG HỢP LỆ(DỂ TRÔNG TÊN )

        [Test]
        public void TestThemMonAn_TraveFalse_NeuTenTrong()
        {
            // Arrange
            string errorMessage;
            int id = 1;
            string name = "";
            int gia = 100;
            string maDanhMuc = "A01";

            // Act
            var result = quanLyMenu.ThemMonAn(id, name, gia, maDanhMuc, out errorMessage);
            TestContext.WriteLine("Thông báo lỗi: " + errorMessage);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual("Tên không được để trống!", errorMessage);
        }

        //SỬA MÓN ĂN(NHẬP GIA TRỊ HỢP LỆ VÀ ID MÓN TỒN TẠI )

        [Test]
        public void TestSuaMonAn_TraVeTrue_GiaTriNhapHopLe()
        {
            // Arrange
            string errorMessage;
            int id = 1;
            string name = "Pizza";
            int gia = 200;
            string maDanhMuc = "A01";

            mockQuanLyMenu.Setup(m => m.CheckIdExists(id)).Returns(true);
            mockQuanLyMenu.Setup(m => m.SuaMenu(id, name, gia, maDanhMuc)).Returns(true);

            // Act
            var result = quanLyMenu.SuaMonAn(id, name, gia, maDanhMuc, out errorMessage);

            // Assert
            Assert.IsTrue(result);
            Assert.IsEmpty(errorMessage);
        }

        // TEST SỬA MÓN KHI ID KHÔNG TỒN TẠI 
        [Test]
        public void TestSuaMonAn_TraVeFalse_IDKhongTonTai()
        {
            // Arrange
            string errorMessage;
            int id = 999;
            string name = "Pizza";
            int gia = 200;
            string maDanhMuc = "A01";

            mockQuanLyMenu.Setup(m => m.CheckIdExists(id)).Returns(false);

            // Act
            var result = quanLyMenu.SuaMonAn(id, name, gia, maDanhMuc, out errorMessage);
            TestContext.WriteLine("Lỗi:" + errorMessage);
            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual("ID này không tồn tại trong menu!", errorMessage);
        }

        //TEST XÓA MON KHI TỒN TẠI ID MÓN TRONG MENU 

        [Test]
        public void TestXoaMon_TraVeTrue_TonTaiID()
        {
            // Arrange
            string errorMessage;
            int id = 1;

            mockQuanLyMenu.Setup(m => m.CheckIdExists(id)).Returns(true);
            mockQuanLyMenu.Setup(m => m.XoaMenu(id)).Returns(true);

            // Act
            var result = quanLyMenu.XoaMon(id, out errorMessage);

            // Assert
            Assert.IsTrue(result);
            Assert.IsEmpty(errorMessage);
        }

        //ID KHÔNG TỒN TẠI 
        [Test]
        public void TestXoaMon_TraVeFalse_KhongTonTaiID()
        {
            // Arrange
            string errorMessage;
            int id = 999;

            mockQuanLyMenu.Setup(m => m.CheckIdExists(id)).Returns(false);

            // Act
            var result = quanLyMenu.XoaMon(id, out errorMessage);
            TestContext.WriteLine("Lỗi: "+ errorMessage);
            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual("ID này không tồn tại trong menu!", errorMessage);
        }
    }
}