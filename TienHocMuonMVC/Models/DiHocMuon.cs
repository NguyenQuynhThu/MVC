using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TienHocMuonMVC.Models
{
    public class DiHocMuon
    {
        public int Id { get; set; }
        public string MaSinhVien { get; set; }
        public string HinhThucNopPhat { get; set; }
        public decimal SoLuong { get; set; }
        public DateTime NgayNopPhat { get; set; }
    }

    public class DiHocMuonListingModel
    {
        public List<DiHocMuon> DSHocMuon { get; set; }
        public decimal TongTien { get; set; }
        public decimal TongChongDay { get; set; }
    }
}