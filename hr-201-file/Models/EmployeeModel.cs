using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hr_201_file.Models
{
    public class EmployeeModel
    {
        DatabaseContext db = new DatabaseContext();
        public List<FileContents> files { get; set; }
        public EmployeeInfo employeeInfo { get; set; }
        public List<FileCategory> categories { get; set; }
    }

    public class EmployeeInfo
    {
        public Employee employee { get; set; }
    }

    public partial class Department
    {
        public Department() {
            this.Employees = new HashSet<Employee>();
        }

        public virtual ICollection<Employee> Employees {get;set;}
    }

    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee 
    {
        public virtual Department Departments { get; set; }
    }
    public partial class EmployeeMetadata
    {
        public int EmpId { get; set; }

        [DisplayName("Employee Number")]
        public Nullable<int> EmpNo { get; set; }

        [DisplayName("Department")]
        public Nullable<int> DeptId { get; set; }

        [DisplayName("Cost Center")]
        public Nullable<int> CostCenterId { get; set; }

        [DisplayName("Branch")]
        public Nullable<int> BranchId { get; set; }

        [DisplayName("Company")]
        public Nullable<int> CompanyId { get; set; }

        [DisplayName("Position")]
        public Nullable<int> JobPositionId { get; set; }

        [DisplayName("Job Category ID")]
        public Nullable<int> JobCategoryId { get; set; }

        [DisplayName("Rank")]
        public Nullable<int> RankCategoryId { get; set; }

        [DisplayName("Employee Type")]
        public Nullable<int> EmpTypeId { get; set; }

        [DisplayName("Employee Fullname")]
        public string FullName { get; set; }

        [DisplayName("Employee Lastname")]
        public string LastName { get; set; }

        [DisplayName("Employee Firstname")]
        public string FirstName { get; set; }

        [DisplayName("Employee Middlename")]
        public string MiddleName { get; set; }

        [DisplayName("Nickname")]
        public string NickName { get; set; }

        [DisplayName("Suffix")]
        public string ExtensionName { get; set; }

        [DisplayName("Current Address")]
        public string Address { get; set; }

        [DisplayName("Provincial Address")]
        public string ProvAddress { get; set; }

        [DisplayName("Email Address")]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNo { get; set; }

        [DisplayName("Region")]
        public string Region { get; set; }

        public string Gender { get; set; }

        [DisplayName("Birthday")]
        public string BirthDate { get; set; }

        [DisplayName("Place of Birth")]
        public string BirthPlace { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }

        [DisplayName("Blood Type")]
        public string BloodType { get; set; }
        public string Religion { get; set; }
        public string Citizenship { get; set; }

        [DisplayName("Mobile Number")]
        public string MobileNo { get; set; }

        [DisplayName("Shift Number")]
        public Nullable<int> ShiftNo { get; set; }

        [DisplayName("Date of Joining")]
        public string JoiningDate { get; set; }

        [DisplayName("Date of Separation")]
        public string SeparationDate { get; set; }

        [DisplayName("Reason of Separation")]
        public string ReasonOfSeparation { get; set; }

        [DisplayName("Casual Expiry Date")]
        public string CasualExpiryDate { get; set; }

        [DisplayName("Probation Expiry Date")]
        public string ProbationExpiryDate { get; set; }

        [DisplayName("Regularization Date")]
        public string RegularizationDate { get; set; }

        [DisplayName("SSS Number")]
        public string SSSNo { get; set; }

        [DisplayName("HDMF Number")]
        public string PagibigNo { get; set; }

        [DisplayName("TIN")]
        public string TINNo { get; set; }

        [DisplayName("Bank Account")]
        public string BankAcctNo { get; set; }

        [DisplayName("Philhealth Number")]
        public string PhilHealthNo { get; set; }

        [DisplayName("Marital Status")]
        public string MaritalStatus { get; set; }

        [DisplayName("Tax Type")]
        public Nullable<int> TaxTypeId { get; set; }

        [DisplayName("Payroll Type")]
        public Nullable<int> PayrollTypeId { get; set; }

        [DisplayName("SSS Eligibility")]
        public Nullable<bool> SSSElig { get; set; }

        [DisplayName("HDMF Eligibility")]
        public Nullable<bool> PagibigElig { get; set; }

        [DisplayName("Tax Eligibility")]
        public Nullable<bool> TaxElig { get; set; }

        [DisplayName("Medical Eligibility")]
        public Nullable<bool> MediElig { get; set; }

        [DisplayName("Pay Restday")]
        public Nullable<decimal> PayRestday { get; set; }

        [DisplayName("Days Per Year")]
        public Nullable<int> DaysPerYear { get; set; }

        [DisplayName("Deduct Allowance")]
        public Nullable<bool> DeductAllowance { get; set; }

        [DisplayName("Sick Leave (SL)")]
        public Nullable<decimal> SLDays { get; set; }

        [DisplayName("Vacation Leave (VL)")]
        public Nullable<decimal> VLDays { get; set; }

        [DisplayName("Service Incentive Leave (SIL)")]
        public Nullable<decimal> SILDays { get; set; }

        [DisplayName("Paternity Leave (PL)")]
        public Nullable<decimal> PaternityDays { get; set; }

        [DisplayName("Relative Contact Number")]
        public string RelativeContactNo { get; set; }

        [DisplayName("Relative Address")]
        public string RelativeAddress { get; set; }

        [DisplayName("Driver's License")]
        public string DriverseLicence { get; set; }

        [DisplayName("Elementary School")]
        public string PrimarySchool { get; set; }

        [DisplayName("Elementary Duration Period")]
        public string PrimaryPeriod { get; set; }

        [DisplayName("Secondary School")]
        public string SecondarySchool { get; set; }

        [DisplayName("Secondary Duration Period")]
        public string SecondaryPeriod { get; set; }

        [DisplayName("Tertiary School")]
        public string TertiarySchool { get; set; }

        [DisplayName("Tertiary Duration Period")]
        public string TertiaryPeriod { get; set; }

        [DisplayName("Tertiary - Course")]
        public string TertiaryCourse { get; set; }

        [DisplayName("Vocational 1")]
        public string VocationalSchool { get; set; }

        [DisplayName("Vocational 2")]
        public string VocationaSchool1 { get; set; }

        [DisplayName("Vocational - Course")]
        public string VocationalCourse { get; set; }

        [DisplayName("Post Graduate")]
        public string PostGraduateSchool { get; set; }

        [DisplayName("Post Graduate Duration Period")]
        public string PostGraduatePeriod { get; set; }

        [DisplayName("Post Graduate - School")]
        public string PostGraduateCourse { get; set; }

        [DisplayName("Government Examination")]
        public string GovExamNature { get; set; }

        [DisplayName("Government Examination Date")]
        public string GovExamDate { get; set; }

        [DisplayName("Government Examination Rating")]
        public string GovExamRating { get; set; }

        [DisplayName("Government Examination License")]
        public string GovExamLicense { get; set; }

        [DisplayName("Name of Father")]
        public string Father { get; set; }

        [DisplayName("Father - Date of Birth")]
        public string FatherBirthDate { get; set; }

        [DisplayName("Father - Contact Number")]
        public string FatherContactNo { get; set; }

        [DisplayName("Father - Educational Attainment")]
        public string FatherEducAttainment { get; set; }

        [DisplayName("Father - Occupation")]
        public string FatherOccupation { get; set; }

        [DisplayName("Father - Company")]
        public string FatherCompany { get; set; }

        [DisplayName("Name of Mother")]
        public string Mother { get; set; }

        [DisplayName("Mother - Date of Birth")]
        public string MotherBirthDate { get; set; }

        [DisplayName("Mother - Contact Number")]
        public string MotherContactNo { get; set; }

        [DisplayName("Mother - Educational Attainment")]
        public string MotherEducAttainment { get; set; }

        [DisplayName("Mother - Occupation")]
        public string MotherOccupation { get; set; }

        [DisplayName("Mother - Company")]
        public string MotherCompany { get; set; }

        [DisplayName("Name of Spouse")]
        public string Spouse { get; set; }

        [DisplayName("Spouse - Date of Birth")]
        public string SpouseBirthDate { get; set; }

        [DisplayName("Spouse - Contact Number")]
        public string SpouseContactNo { get; set; }

        [DisplayName("Spouse - Educational Attainment")]
        public string SpouseEducAttainment { get; set; }

        [DisplayName("Spouse - Occupation")]
        public string SpouseOccupation { get; set; }

        [DisplayName("Spouse - Company")]
        public string SpouseCompany { get; set; }

        [DisplayName("Date Transfer to Staff")]
        public string DateTransferToStaff { get; set; }

        [DisplayName("Date of Transfer")]
        public string DateOfTransfer { get; set; }

        [DisplayName("Contract Start")]
        public string ContractStart { get; set; }

        [DisplayName("Contract End")]
        public string ContractEnd { get; set; }

        [DisplayName("Salary Remarks")]
        public string SalaryRemarks { get; set; }

        [DisplayName("Medical Status")]
        public string MedicalStatus { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }

        [DisplayName("Employment Status")]
        public Nullable<int> EmploymentStatusId { get; set; }
        public Nullable<bool> Active { get; set; }
        public string UserTrailTrack { get; set; }
        public string UserLogStamp { get; set; }

        public virtual Position JobPosition { get; set; }
    }
}