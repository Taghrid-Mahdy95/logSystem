﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro v5.5.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using LogSystemTutorial.FactoryClasses;
using LogSystemTutorial.RelationClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace LogSystemTutorial.HelperClasses
{
	/// <summary>Singleton implementation of the ModelInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	public static class ModelInfoProviderSingleton
	{
		private static readonly IModelInfoProvider _providerInstance = new ModelInfoProviderCore();

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static ModelInfoProviderSingleton()	{ }

		/// <summary>Gets the singleton instance of the ModelInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IModelInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the ModelInfoProvider.</summary>
	internal class ModelInfoProviderCore : ModelInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="ModelInfoProviderCore"/> class.</summary>
		internal ModelInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			this.InitClass();
			InitEntryEntityInfo();
			InitProjectEntityInfo();
			InitUserEntityInfo();
			InitVersionInfoEntityInfo();
			this.BuildInternalStructures();
		}

		/// <summary>Inits EntryEntity's info objects</summary>
		private void InitEntryEntityInfo()
		{
			this.AddFieldIndexEnumForElementName(typeof(EntryFieldIndex), "EntryEntity");
			this.AddElementFieldInfo("EntryEntity", "Date", typeof(System.DateTime), false, false, false, false,  (int)EntryFieldIndex.Date, 0, 0, 0);
			this.AddElementFieldInfo("EntryEntity", "Description", typeof(System.String), false, false, false, false,  (int)EntryFieldIndex.Description, 1073741824, 0, 0);
			this.AddElementFieldInfo("EntryEntity", "Id", typeof(System.Int64), true, false, true, false,  (int)EntryFieldIndex.Id, 0, 0, 20);
			this.AddElementFieldInfo("EntryEntity", "ProjectId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)EntryFieldIndex.ProjectId, 0, 0, 20);
			this.AddElementFieldInfo("EntryEntity", "TimeSpent", typeof(System.Int32), false, false, false, false,  (int)EntryFieldIndex.TimeSpent, 0, 0, 10);
			this.AddElementFieldInfo("EntryEntity", "UserId", typeof(System.Int64), false, true, false, false,  (int)EntryFieldIndex.UserId, 0, 0, 20);
		}

		/// <summary>Inits ProjectEntity's info objects</summary>
		private void InitProjectEntityInfo()
		{
			this.AddFieldIndexEnumForElementName(typeof(ProjectFieldIndex), "ProjectEntity");
			this.AddElementFieldInfo("ProjectEntity", "Description", typeof(System.String), false, false, false, true,  (int)ProjectFieldIndex.Description, 1073741824, 0, 0);
			this.AddElementFieldInfo("ProjectEntity", "Id", typeof(System.Int64), true, false, true, false,  (int)ProjectFieldIndex.Id, 0, 0, 20);
			this.AddElementFieldInfo("ProjectEntity", "Logo", typeof(System.String), false, false, false, false,  (int)ProjectFieldIndex.Logo, 1073741824, 0, 0);
			this.AddElementFieldInfo("ProjectEntity", "LogoImage", typeof(System.String), false, false, false, true,  (int)ProjectFieldIndex.LogoImage, 1073741824, 0, 0);
			this.AddElementFieldInfo("ProjectEntity", "Name", typeof(System.String), false, false, false, false,  (int)ProjectFieldIndex.Name, 1073741824, 0, 0);
			this.AddElementFieldInfo("ProjectEntity", "Status", typeof(System.Boolean), false, false, false, false,  (int)ProjectFieldIndex.Status, 0, 0, 0);
		}

		/// <summary>Inits UserEntity's info objects</summary>
		private void InitUserEntityInfo()
		{
			this.AddFieldIndexEnumForElementName(typeof(UserFieldIndex), "UserEntity");
			this.AddElementFieldInfo("UserEntity", "Email", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Email, 1073741824, 0, 0);
			this.AddElementFieldInfo("UserEntity", "Id", typeof(System.Int64), true, false, true, false,  (int)UserFieldIndex.Id, 0, 0, 20);
			this.AddElementFieldInfo("UserEntity", "Name", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Name, 1073741824, 0, 0);
			this.AddElementFieldInfo("UserEntity", "Password", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Password, 1073741824, 0, 0);
		}

		/// <summary>Inits VersionInfoEntity's info objects</summary>
		private void InitVersionInfoEntityInfo()
		{
			this.AddFieldIndexEnumForElementName(typeof(VersionInfoFieldIndex), "VersionInfoEntity");
			this.AddElementFieldInfo("VersionInfoEntity", "AppliedOn", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)VersionInfoFieldIndex.AppliedOn, 0, 0, 0);
			this.AddElementFieldInfo("VersionInfoEntity", "Description", typeof(System.String), false, false, false, true,  (int)VersionInfoFieldIndex.Description, 1024, 0, 0);
			this.AddElementFieldInfo("VersionInfoEntity", "Version", typeof(System.Int64), false, false, false, false,  (int)VersionInfoFieldIndex.Version, 0, 0, 20);
		}
	}
}