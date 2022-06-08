using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Test.NongNghiep;

string connectionString = MySqlConnectionProvider.GetConnectionString("localhost", "root", "aion43", "nongnghiep");
XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.None);

UnitOfWork uow = new();
DataImages di = new(uow) {
    Name = "Hello world",
    FileImage = "From XPO",
    TimestartCapture = DateTime.Now,
    StationId = Guid.NewGuid().ToString()
};
uow.CommitChanges();
