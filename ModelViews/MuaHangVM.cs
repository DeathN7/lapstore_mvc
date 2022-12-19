using System;
using System.ComponentModel.DataAnnotations;

namespace testmvc.ModelViews
{
    public class MuaHangVM
    {

        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Họ và Tên")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Phone { get; set; }
        public int PaymentID { get; set; }
    }
}
