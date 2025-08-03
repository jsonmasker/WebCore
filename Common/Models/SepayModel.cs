using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class SepayModel
    {
        // ID giao dịch trên SePay
        public int Id { get; set; }

        // Brand name của ngân hàng
        public string Gateway { get; set; }

        // Thời gian xảy ra giao dịch phía ngân hàng
        public string TransactionDate { get; set; }

        // Số tài khoản ngân hàng
        public string AccountNumber { get; set; }

        // Mã code thanh toán (sepay tự nhận diện dựa vào cấu hình tại Công ty -> Cấu hình chung)
        public string? Code { get; set; }

        // Nội dung chuyển khoản
        public string Content { get; set; }

        // Loại giao dịch. in là tiền vào, out là tiền ra
        public string TransferType { get; set; }

        // Số tiền giao dịch
        public decimal TransferAmount { get; set; }

        // Số dư tài khoản (lũy kế)
        public decimal Accumulated { get; set; }

        // Tài khoản ngân hàng phụ (tài khoản định danh)
        public string? SubAccount { get; set; }

        // Mã tham chiếu của tin nhắn sms
        public string ReferenceCode { get; set; }

        // Toàn bộ nội dung tin nhắn sms
        public string? Description { get; set; }
    }
}
