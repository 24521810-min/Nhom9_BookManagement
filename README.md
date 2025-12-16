# BookManagement - ỨNG DỤNG QUẢN LÝ SÁCH ĐA NĂNG

## Thành viên nhóm 
- Đăng Huyền Trân 24521810
- Nguyễn Thị Tuyết Thoa 24521719
- Huỳnh Minh Tú 24521907
- Võ Lê Uyên Trang 24521823

## Mô tả

Ứng dụng được xây dựng nhằm hỗ trợ quản lý trực tuyến các hoạt động mượn sách, trả sách và quyên góp sách, giúp người dùng và quản trị viên thao tác với hệ thống thư viện một cách nhanh chóng và thuận tiện.

Người dùng có thể tìm kiếm sách, gửi yêu cầu mượn hoặc trả sách, đồng thời quyên góp sách trực tiếp thông qua giao diện client.
Hệ thống được triển khai theo mô hình Client – Server, trong đó:

- Client đảm nhiệm phần giao diện tương tác với người dùng (User) và quản trị viên (Admin).
- Server được xây dựng dưới dạng API, chịu trách nhiệm: Xử lý logic nghiệp vụ (business logic); Xác thực và phân quyền tài khoản; Tiếp nhận yêu cầu từ client; Truy xuất, cập nhật và lưu trữ dữ liệu vào cơ sở dữ liệu; Gửi email thông báo đến người dùng trong các trường hợp: mượn sách, trả sách, quyên góp thành công.

Hệ thống có hai giao diện chính:

- Giao diện Admin, hệ thống cung cấp các chức năng quản lý bao gồm:
    * Kho sách: Xem danh sách sách, số lượng, tình trạng; Thêm mới sách vào kho; Tìm kiếm, chỉnh sửa hoặc xóa sách.
    * Quản lý quyên góp: Nhận danh sách sách người dùng đã gửi yêu cầu quyên góp; Duyệt hoặc từ chối yêu cầu; Khi duyệt, hệ thống tự động cập nhật kho sách và gửi email xác nhận cho người dùng.
    * Quản lý mượn/ trả: Theo dõi tất cả yêu cầu mượn và trả; Duyệt yêu cầu mượn/trả; Hệ thống tự xử lý cập nhật trạng thái sách và gửi email thông báo mượn/trả thành công.
    * Quản lý người dùng: theo dõi, tìm kiếm, xóa, phân quyền, khóa/mở tài khoản người dùng.  
- Giao diện User, hệ thống cho phép:
    * Mượn sách: Người dùng xem danh sách sách và gửi yêu cầu mượn; Hệ thống kiểm tra sách còn hay đã được mượn; Khi admin duyệt, người dùng nhận email xác nhận mượn thành công.
    * Trả sách: Người dùng gửi thông báo trả sách; Admin xác nhận và cập nhật trạng thái sách; Hệ thống lưu lịch sử và gửi email xác nhận.
    * Quyên góp sách: Người dùng gửi thông tin sách muốn quyên góp; Chờ admin duyệt để đưa sách vào kho; Nhận email thông báo khi quyên góp được chấp nhận.
## Hướng dẫn cài đặt: 
Visual Studio

.NET Framework 4.8

ASP.NET Core Web API

Microsoft SQL Server 2022

## Cách cài đặt & chạy project: 
### 1. Clone repository về máy
* Sao chép repository từ GitHub về máy cục bộ:
```
   git clone https://github.com/24521810-min/Nhom9_BookManagement.git
   cd Nhom9_BookManagement.git
```
* Sau khi clone xong, mở project trong Visual Studio bằng file .sln.
* Chọn View --> Solution Explorer --> Kích chuột phải vào "Solution 'BookManagement' --> Configure Startup Projects --> Chọn Multiple startup projects để chạy cùng lúc Client và Server --> Thiết lập Client và Server: Start
### 2. Tạo cơ sở dữ liệu

Trong tệp BookManagement, chạy file BookManagement.sql và Microsoft SQL Server Management Studio (SSMS) để tạo cơ sở dữ liệu cần thiết.

### 3. Sửa địa chỉ server
* Mở appsettings.json trong Server
* Cấu hình kết nối Sql
```sql
"ConnectionStrings": {
  "DefaultConnection": "Data Source=localhost;Initial Catalog=BookManagementDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
},
```
⚠️ Lưu ý: Cần thay thế localhost bằng tên Server và Instance thực tế trên máy tính của bạn.
### 4. Khởi chạy dự án

Sử dụng Visual Studio để mở và chạy dự án.
