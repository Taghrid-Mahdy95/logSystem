﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.5.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace LogSystemTutorial.HelperClasses
{
	/// <summary>Field Creation Class for entity EntryEntity</summary>
	public partial class EntryFields
	{
		/// <summary>Creates a new EntryEntity.Date field instance</summary>
		public static EntityField2 Date { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(EntryFieldIndex.Date); }}
		/// <summary>Creates a new EntryEntity.Description field instance</summary>
		public static EntityField2 Description { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(EntryFieldIndex.Description); }}
		/// <summary>Creates a new EntryEntity.Id field instance</summary>
		public static EntityField2 Id { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(EntryFieldIndex.Id); }}
		/// <summary>Creates a new EntryEntity.ProjectId field instance</summary>
		public static EntityField2 ProjectId { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(EntryFieldIndex.ProjectId); }}
		/// <summary>Creates a new EntryEntity.TimeSpent field instance</summary>
		public static EntityField2 TimeSpent { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(EntryFieldIndex.TimeSpent); }}
		/// <summary>Creates a new EntryEntity.UserId field instance</summary>
		public static EntityField2 UserId { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(EntryFieldIndex.UserId); }}
	}

	/// <summary>Field Creation Class for entity ProjectEntity</summary>
	public partial class ProjectFields
	{
		/// <summary>Creates a new ProjectEntity.Description field instance</summary>
		public static EntityField2 Description { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ProjectFieldIndex.Description); }}
		/// <summary>Creates a new ProjectEntity.Id field instance</summary>
		public static EntityField2 Id { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ProjectFieldIndex.Id); }}
		/// <summary>Creates a new ProjectEntity.Logo field instance</summary>
		public static EntityField2 Logo { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ProjectFieldIndex.Logo); }}
		/// <summary>Creates a new ProjectEntity.LogoImage field instance</summary>
		public static EntityField2 LogoImage { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ProjectFieldIndex.LogoImage); }}
		/// <summary>Creates a new ProjectEntity.Name field instance</summary>
		public static EntityField2 Name { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ProjectFieldIndex.Name); }}
		/// <summary>Creates a new ProjectEntity.Status field instance</summary>
		public static EntityField2 Status { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(ProjectFieldIndex.Status); }}
	}

	/// <summary>Field Creation Class for entity UserEntity</summary>
	public partial class UserFields
	{
		/// <summary>Creates a new UserEntity.Email field instance</summary>
		public static EntityField2 Email { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.Email); }}
		/// <summary>Creates a new UserEntity.Id field instance</summary>
		public static EntityField2 Id { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.Id); }}
		/// <summary>Creates a new UserEntity.Name field instance</summary>
		public static EntityField2 Name { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.Name); }}
		/// <summary>Creates a new UserEntity.Password field instance</summary>
		public static EntityField2 Password { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(UserFieldIndex.Password); }}
	}

	/// <summary>Field Creation Class for entity VersionInfoEntity</summary>
	public partial class VersionInfoFields
	{
		/// <summary>Creates a new VersionInfoEntity.AppliedOn field instance</summary>
		public static EntityField2 AppliedOn { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(VersionInfoFieldIndex.AppliedOn); }}
		/// <summary>Creates a new VersionInfoEntity.Description field instance</summary>
		public static EntityField2 Description { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(VersionInfoFieldIndex.Description); }}
		/// <summary>Creates a new VersionInfoEntity.Version field instance</summary>
		public static EntityField2 Version { get { return ModelInfoProviderSingleton.GetInstance().CreateField2(VersionInfoFieldIndex.Version); }}
	}
	

}