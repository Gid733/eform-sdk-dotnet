﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace eFormShared
{
    #region Template_Dto
    public class Template_Dto
    {
        #region con
        public Template_Dto()
        {

        }

        public Template_Dto(int id, DateTime? createdAt, DateTime? updatedAt, string label, string description, int repeated, string folderName, string workflowState, List<SiteName_Dto> deployedSites, bool hasCases)
        {
            Id = id;
            Label = label;
            Description = description;
            Repeated = repeated;
            FolderName = folderName;
            WorkflowState = workflowState;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeployedSites = deployedSites;
            HasCases = hasCases;
        }
        #endregion

        #region var
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; }

        /// <summary>
        ///...
        /// </summary>
        public DateTime? CreatedAt { get; }

        /// <summary>
        ///...
        /// </summary>
        public DateTime? UpdatedAt { get; }

        /// <summary>
        /// Label
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Descrition
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Repeated
        /// </summary>
        public int Repeated { get; }

        /// <summary>
        /// FolderName
        /// </summary>
        public string FolderName { get; }

        /// <summary>
        /// WorkflowState
        /// </summary>
        public string WorkflowState { get; }

        /// <summary>
        /// WorkflowState
        /// </summary>
        public List<SiteName_Dto> DeployedSites { get; }

        /// <summary>
        /// WorkflowState
        /// </summary>
        public bool HasCases { get; }
        #endregion
    }
    #endregion

    #region Field_Dto
    public class Field_Dto
    {
        #region con
        public Field_Dto()
        {

        }

        public Field_Dto(int id, string label, string description, int fieldTypeId)
        {
            Id = id;
            Label = label;
            Description = description;
            FieldTypeId = fieldTypeId;
        }
        #endregion

        #region var
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Label
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Descrition
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Repeated
        /// </summary>
        public int FieldTypeId { get; }

        #endregion
    }
    #endregion

    #region Case_Dto
    public class Case_Dto
    {
        #region con
        public Case_Dto()
        {
        }

        public Case_Dto(string stat, int siteUId, string caseType, string caseUId, string microtingUId, string checkUId, string custom, int checkListId)
        {
            if (caseType == null)
                caseType = "";
            if (caseUId == null)
                caseUId = "";
            if (microtingUId == null)
                microtingUId = "";
            if (checkUId == null)
                checkUId = "";

            Stat = stat;
            SiteUId = siteUId;
            CaseType = caseType;
            CaseUId = caseUId;
            MicrotingUId = microtingUId;
            CheckUId = checkUId;
            Custom = custom;
            CheckListId = checkListId;
        }
        #endregion

        #region var
        /// <summary>
        /// Status of the case
        /// </summary>
        public string Stat { get; }

        /// <summary>
        /// Unique identifier of device
        /// </summary>
        public int SiteUId { get; }

        /// <summary>
        /// Identifier of a collection of cases in your system
        /// </summary>
        public string CaseType { get; }

        /// <summary>
        /// Unique identifier of a group of case(s) in your system
        /// </summary>
        public string CaseUId { get; }

        /// <summary>
        ///Unique identifier of that specific eForm in Microting system
        /// </summary>
        public string MicrotingUId { get; }

        /// <summary>
        /// Unique identifier of that check of the eForm. Only used if repeat
        /// </summary>
        public string CheckUId { get; }

        /// <summary>
        /// Custom data. Only used in special cases
        /// </summary>
        public string Custom { get; }

        /// <summary>
        /// Unique identifier of device
        /// </summary>
        public int CheckListId { get; }
        #endregion

        public override string ToString()
        {
            if (CheckUId == null) return "Stat:" + Stat + " / SiteUId:" + SiteUId + " / CaseType:" + CaseType + " / CaseUId:" + CaseUId + " / MicrotingUId:" + MicrotingUId + ".";
            if (CheckUId == "") return "Stat:" + Stat + " / SiteUId:" + SiteUId + " / CaseType:" + CaseType + " / CaseUId:" + CaseUId + " / MicrotingUId:" + MicrotingUId + ".";
            return "Stat:" + Stat + " / SiteUId:" + SiteUId + " / CaseType:" + CaseType + " / CaseUId:" + CaseUId + " / MicrotingUId:" + MicrotingUId + " / CheckId:" + CheckUId + ".";
        }
    }
    #endregion

    #region File_Dto
    public class File_Dto
    {
        #region con
        public File_Dto(int siteUId, string caseType, string caseUId, string microtingUId, string checkUId, string fileLocation)
        {
            if (caseType == null)
                caseType = "";
            if (caseUId == null)
                caseUId = "";
            if (microtingUId == null)
                microtingUId = "";
            if (checkUId == null)
                checkUId = "";
            if (fileLocation == null)
                fileLocation = "";

            SiteUId = siteUId;
            CaseType = caseType;
            CaseUId = caseUId;
            MicrotingUId = microtingUId;
            CheckUId = checkUId;
            FileLocation = fileLocation;
        }
        #endregion

        #region var
        /// <summary>
        /// Unique identifier of device
        /// </summary>
        public int SiteUId { get; }

        /// <summary>
        /// Identifier of a collection of cases in your system
        /// </summary>
        public string CaseType { get; }

        /// <summary>
        /// Unique identifier of a group of case(s) in your system
        /// </summary>
        public string CaseUId { get; }

        /// <summary>
        ///Unique identifier of that specific eForm in Microting system
        /// </summary>
        public string MicrotingUId { get; }

        /// <summary>
        /// Unique identifier of that check of the eForm. Only used if repeat
        /// </summary>
        public string CheckUId { get; }

        /// <summary>
        /// Location of the fil
        /// </summary>
        public string FileLocation { get; set; }
        #endregion

        public override string ToString()
        {
            return "SiteUId:" + SiteUId + " / CaseType:" + CaseType + " / CaseUId:" + CaseUId + " / MicrotingUId:" + MicrotingUId + " / CheckId:" + CheckUId + " / FileLocation:" + FileLocation;
        }
    }
    #endregion

    #region Site_Dto
    public class Site_Dto
    {
        #region con
        public Site_Dto()
        {
        }

        public Site_Dto(int siteId, string siteName, string userFirstName, string userLastName, int? customerNo, int? otpCode, int? unitId, int? workerUid)
        {
            if (siteName == null)
                siteName = "";
            if (userFirstName == null)
                userFirstName = "";
            if (userLastName == null)
                userLastName = "";

            SiteId = siteId;
            SiteName = siteName;
            FirstName = userFirstName;
            LastName = userLastName;
            CustomerNo = customerNo;
            OtpCode = otpCode;
            UnitId = unitId;
            WorkerUid = workerUid;
        }
        #endregion

        #region var
        /// <summary>
        ///...
        /// </summary>
        public int SiteId { get; }

        /// <summary>
        ///...
        /// </summary>
        public string SiteName { get; }

        /// <summary>
        ///...
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        ///...
        /// </summary>
        public string LastName { get; }

        /// <summary>
        ///...
        /// </summary>
        public int? CustomerNo { get; }

        /// <summary>
        ///...
        /// </summary>
        public int? OtpCode { get; }

        /// <summary>
        ///...
        /// </summary>
        public int? UnitId { get; }

        /// <summary>
        ///...
        /// </summary>
        public int? WorkerUid { get; }
        #endregion

        public override string ToString()
        {
            return "SiteId:" + SiteId + " / SiteName:" + SiteName + " / FirstName:" + FirstName + " / LastName:" + LastName + " / CustomerNo:" + CustomerNo + " / OtpCode:" + OtpCode + "UnitId:" + UnitId + "WorkerUid:" + WorkerUid + ".";
        }
    }
    #endregion

    #region SiteName_Dto
    public class SiteName_Dto
    {
        #region con
        public SiteName_Dto()
        {
        }

        public SiteName_Dto(int siteUId, string siteName, DateTime? createdAt, DateTime? updatedAt)
        {
            if (siteName == null)
                siteName = "";

            SiteUId = siteUId;
            SiteName = siteName;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        #endregion

        #region var
        /// <summary>
        ///...
        /// </summary>
        public int SiteUId { get; }

        /// <summary>
        ///...
        /// </summary>
        public string SiteName { get; }

        /// <summary>
        ///...
        /// </summary>
        public DateTime? CreatedAt { get; }

        /// <summary>
        ///...
        /// </summary>
        public DateTime? UpdatedAt { get; }

        #endregion

        public override string ToString()
        {
            return "SiteUId:" + SiteUId + " / SiteName:" + SiteName + " / CreatedAt:" + CreatedAt + " / UpdatedAt:" + UpdatedAt + ".";
        }
    }
    #endregion

    #region Worker_Dto
    public class Worker_Dto
    {
        #region con
        public Worker_Dto()
        {
        }

        public Worker_Dto(int workerUId, string firstName, string lastName, string email, DateTime? createdAt, DateTime? updatedAt)
        {
            if (firstName == null)
                firstName = "";

            if (lastName == null)
                lastName = "";

            if (email == null)
                email = "";

            WorkerUId = workerUId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        #endregion

        #region var
        /// <summary>
        ///...
        /// </summary>
        public int WorkerUId { get; }

        /// <summary>
        ///...
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        ///...
        /// </summary>
        public string LastName { get; }

        /// <summary>
        ///...
        /// </summary>
        public string Email { get; }

        /// <summary>
        ///...
        /// </summary>
        public DateTime? CreatedAt { get; }

        /// <summary>
        ///...
        /// </summary>
        public DateTime? UpdatedAt { get; }

        #endregion

        public override string ToString()
        {
            return "WorkerUId:" + WorkerUId + " / FirstName:" + FirstName + " / LastName:" + LastName + " / Email:" + Email + " / CreatedAt:" + CreatedAt + " / UpdatedAt:" + UpdatedAt + ".";
        }
    }
    #endregion

    #region Site_Worker_Dto
    public class Site_Worker_Dto
    {
        #region con
        public Site_Worker_Dto()
        {
        }

        public Site_Worker_Dto(int microtingUId, int siteUId, int workerUId)
        {
            MicrotingUId = microtingUId;
            SiteUId = siteUId;
            WorkerUId = workerUId;
        }
        #endregion

        #region var
        /// <summary>
        ///...
        /// </summary>
        public int MicrotingUId { get; }

        /// <summary>
        ///...
        /// </summary>
        public int SiteUId { get; }

        /// <summary>
        ///...
        /// </summary>
        public int WorkerUId { get; }

        #endregion

        public override string ToString()
        {
            return "MicrotingUId:" + MicrotingUId + " / SiteUId:" + SiteUId + " / WorkerUId:" + WorkerUId + ".";
        }
    }
    #endregion

    #region Unit_Dto
    public class Unit_Dto
    {
        #region con
        public Unit_Dto()
        {
        }

        public Unit_Dto(int unitUId, int customerNo, int otpCode, int siteUId, DateTime? createdAt, DateTime? updatedAt)
        {
            UnitUId = unitUId;
            CustomerNo = customerNo;
            OtpCode = otpCode;
            SiteUId = siteUId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        #endregion

        #region var
        /// <summary>
        ///...
        /// </summary>
        public int UnitUId { get; }

        /// <summary>
        ///...
        /// </summary>
        public int CustomerNo { get; }

        /// <summary>
        ///...
        /// </summary>
        public int OtpCode { get; }

        /// <summary>
        ///...
        /// </summary>
        public int SiteUId { get; }

        /// <summary>
        ///...
        /// </summary>
        public DateTime? CreatedAt { get; }

        /// <summary>
        ///...
        /// </summary>
        public DateTime? UpdatedAt { get; }

        #endregion

        public override string ToString()
        {
            return "UnitUId:" + UnitUId + " / CustomerNo:" + CustomerNo + " / OtpCode:" + OtpCode + " / SiteUId:" + SiteUId + " / CreatedAt:" + CreatedAt + " / UpdatedAt:" + UpdatedAt + ".";
        }
    }
    #endregion

    #region Organization_Dto
    public class Organization_Dto
    {
        #region con
        public Organization_Dto()
        {
        }

        public Organization_Dto(int organizationUid, string name, int customerNo, int unitLicenseNumber, string awsEndPoint, string awsId, string awsKey, string comAddress, string comAddressBasic, string subscriberAddress, string subscriberToken, string subscriberName)
        {
            OrganizationUid = organizationUid;
            Name = name;
            CustomerNo = customerNo;
            UnitLicenseNumber = unitLicenseNumber;
            AwsEndPoint = awsEndPoint;
            AwsId = awsId;
            AwsKey = awsKey;
            ComAddress = comAddress;
            ComAddressBasic = comAddressBasic;
            SubscriberAddress = subscriberAddress;
            SubscriberToken = subscriberToken;
            SubscriberName = subscriberName;
        }
        #endregion

        #region var
        /// <summary>
        ///...
        /// </summary>
        public int OrganizationUid { get; }

        /// <summary>
        ///...
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///...
        /// </summary>
        public int CustomerNo { get; }

        /// <summary>
        ///...
        /// </summary>
        public int UnitLicenseNumber { get; }

        /// <summary>
        ///...
        /// </summary>
        public string AwsEndPoint { get; }

        /// <summary>
        ///...
        /// </summary>
        public string AwsId { get; }

        /// <summary>
        ///...
        /// </summary>
        public string AwsKey { get; }

        /// <summary>
        ///...
        /// </summary>
        public string ComAddress { get; }

        /// <summary>
        ///...
        /// </summary>
        public string ComAddressBasic { get; }

        /// <summary>
        ///...
        /// </summary>
        public string SubscriberAddress { get; }

        /// <summary>
        ///...
        /// </summary>
        public string SubscriberToken { get; }

        /// <summary>
        ///...
        /// </summary>
        public string SubscriberName { get; }

        #endregion

        public override string ToString()
        {
            return "OrganizationUid:" + OrganizationUid + " / Name:" + Name + " / CustomerNo:" + CustomerNo + " / SiteUId:" + UnitLicenseNumber + ".";
        }
    }
    #endregion

    #region Holder
    public class Holder
    {
        public Holder(int index, string field_type)
        {
            Index = index;
            FieldType = field_type;
        }

        public int Index { get; }

        public string FieldType { get; }
    }
    #endregion

    #region EntityItemUpdateInfo
    public class EntityItemUpdateInfo
    {
        public EntityItemUpdateInfo(string entityItemMUid, string status)
        {
            EntityItemMUid = entityItemMUid;
            Status = status;
        }

        public string EntityItemMUid { get; set; }
        public string Status { get; set; }
    }
    #endregion

    #region KeyValuePair
    [Serializable()]
    public class KeyValuePair
    {
        #region con
        internal KeyValuePair()
        {

        }

        public KeyValuePair(string key, string value, bool selected, string displayOrder)
        {
            Key = key;
            Value = value;
            Selected = selected;
            DisplayOrder = displayOrder;
        }
        #endregion

        #region var
        public string Key { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; }
        public string DisplayOrder { get; set; }
        #endregion
    }
    #endregion

    #region CDataValue
    public class CDataValue
    {
        [XmlIgnore]
        public string InderValue { get; set; }

        [XmlText]
        public XmlNode[] CDataWrapper
        {
            get
            {
                var dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(InderValue) };
            }
            set
            {
                if (value == null)
                {
                    InderValue = null;
                    return;
                }

                if (value.Length != 1)
                {
                    throw new InvalidOperationException(
                        String.Format(
                            "Invalid array length {0}", value.Length));
                }

                InderValue = value[0].Value;
            }
        }
    }
    #endregion
}
