/*
 Navicat Premium Data Transfer

 Source Server         : sqlserver
 Source Server Type    : SQL Server
 Source Server Version : 15002000
 Source Catalog        : RightControl
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002000
 File Encoding         : 65001

 Date: 27/05/2023 10:12:12
*/


-- ----------------------------
-- Table structure for t_action
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[t_action]') AND type IN ('U'))
	DROP TABLE [dbo].[t_action]
GO

CREATE TABLE [dbo].[t_action] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [ActionCode] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [ActionName] varchar(40) COLLATE Chinese_PRC_CI_AS  NULL,
  [Position] int  NULL,
  [ClassName] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [Icon] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [Method] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [Remark] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [OrderBy] int  NULL,
  [Status] bit  NULL,
  [CreateOn] datetime  NULL,
  [UpdateOn] datetime  NULL,
  [CreateBy] int  NULL,
  [UpdateBy] int  NULL
)
GO

ALTER TABLE [dbo].[t_action] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'ID',
'SCHEMA', N'dbo',
'TABLE', N't_action',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作编码',
'SCHEMA', N'dbo',
'TABLE', N't_action',
'COLUMN', N'ActionCode'
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作名称',
'SCHEMA', N'dbo',
'TABLE', N't_action',
'COLUMN', N'ActionName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'显示位置（1：表单内，2：表单右上）',
'SCHEMA', N'dbo',
'TABLE', N't_action',
'COLUMN', N'Position'
GO

EXEC sp_addextendedproperty
'MS_Description', N'样式名称',
'SCHEMA', N'dbo',
'TABLE', N't_action',
'COLUMN', N'ClassName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'图标',
'SCHEMA', N'dbo',
'TABLE', N't_action',
'COLUMN', N'Icon'
GO

EXEC sp_addextendedproperty
'MS_Description', N'方法名称',
'SCHEMA', N'dbo',
'TABLE', N't_action',
'COLUMN', N'Method'
GO

EXEC sp_addextendedproperty
'MS_Description', N'说明',
'SCHEMA', N'dbo',
'TABLE', N't_action',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'排序号',
'SCHEMA', N'dbo',
'TABLE', N't_action',
'COLUMN', N'OrderBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'状态',
'SCHEMA', N'dbo',
'TABLE', N't_action',
'COLUMN', N'Status'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N't_action',
'COLUMN', N'CreateOn'
GO

EXEC sp_addextendedproperty
'MS_Description', N'更新时间',
'SCHEMA', N'dbo',
'TABLE', N't_action',
'COLUMN', N'UpdateOn'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建者',
'SCHEMA', N'dbo',
'TABLE', N't_action',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'更新者',
'SCHEMA', N'dbo',
'TABLE', N't_action',
'COLUMN', N'UpdateBy'
GO


-- ----------------------------
-- Records of [t_action]
-- ----------------------------
SET IDENTITY_INSERT [dbo].[t_action] ON
GO

INSERT INTO [dbo].[t_action] ([Id], [ActionCode], [ActionName], [Position], [ClassName], [Icon], [Method], [Remark], [OrderBy], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'1', N'Add', N'添加', N'1', NULL, N'icon-add', N'Add', NULL, N'0', N'1', N'2022-07-23 14:44:33.000', N'2022-07-24 23:32:07.000', N'0', N'1')
GO

INSERT INTO [dbo].[t_action] ([Id], [ActionCode], [ActionName], [Position], [ClassName], [Icon], [Method], [Remark], [OrderBy], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'2', N'edit', N'编辑', N'0', NULL, N'icon-bianji', N'edit', NULL, N'0', N'1', N'2022-07-23 14:44:36.000', N'2022-07-24 14:45:21.000', N'0', N'0')
GO

INSERT INTO [dbo].[t_action] ([Id], [ActionCode], [ActionName], [Position], [ClassName], [Icon], [Method], [Remark], [OrderBy], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'3', N'detail', N'查看', N'0', N'layui-btn-normal', N'icon-chakan', N'detail', NULL, N'0', N'1', N'2019-02-23 14:44:39.000', N'2022-07-24 14:45:24.000', N'0', N'0')
GO

INSERT INTO [dbo].[t_action] ([Id], [ActionCode], [ActionName], [Position], [ClassName], [Icon], [Method], [Remark], [OrderBy], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'4', N'del', N'删除', N'0', N'layui-btn-danger', N'icon-guanbi', N'del', NULL, N'0', N'1', N'2022-07-23 14:44:42.000', N'2022-07-24 14:45:27.000', N'0', N'0')
GO

INSERT INTO [dbo].[t_action] ([Id], [ActionCode], [ActionName], [Position], [ClassName], [Icon], [Method], [Remark], [OrderBy], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'5', N'reset', N'重置密码', N'0', N'layui-btn-warm', N'icon-reset', N'reset', NULL, N'0', N'1', N'2022-07-23 14:44:45.000', N'2022-07-24 23:34:55.000', N'0', N'1')
GO

INSERT INTO [dbo].[t_action] ([Id], [ActionCode], [ActionName], [Position], [ClassName], [Icon], [Method], [Remark], [OrderBy], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'6', N'assign', N'分配权限', N'0', N'', N'icon-jiaoseguanli', N'assign', NULL, N'0', N'1', N'2022-07-23 14:44:48.000', N'2022-07-24 14:45:34.000', N'0', N'0')
GO

INSERT INTO [dbo].[t_action] ([Id], [ActionCode], [ActionName], [Position], [ClassName], [Icon], [Method], [Remark], [OrderBy], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'7', N'BatchDel', N'批量删除', N'1', NULL, N'icon-shanchu', N'BatchDel', NULL, N'0', N'1', N'2022-07-23 14:45:15.000', N'2022-07-24 17:00:29.000', N'1', N'0')
GO

INSERT INTO [dbo].[t_action] ([Id], [ActionCode], [ActionName], [Position], [ClassName], [Icon], [Method], [Remark], [OrderBy], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'8', N'menu_action', N'菜单权限', N'0', NULL, N'icon-setting-permissions', N'menu_action', NULL, N'0', N'1', N'2022-07-23 17:00:29.000', N'2022-07-24 16:07:46.000', N'0', N'1')
GO

SET IDENTITY_INSERT [dbo].[t_action] OFF
GO


-- ----------------------------
-- Table structure for t_menu
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[t_menu]') AND type IN ('U'))
	DROP TABLE [dbo].[t_menu]
GO

CREATE TABLE [dbo].[t_menu] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [MenuName] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [MenuUrl] varchar(60) COLLATE Chinese_PRC_CI_AS  NULL,
  [MenuIcon] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [OrderNo] int  NULL,
  [ParentId] int  NULL,
  [Status] bit  NULL,
  [CreateOn] datetime  NULL,
  [UpdateOn] datetime  NULL,
  [CreateBy] int  NULL,
  [UpdateBy] int  NULL
)
GO

ALTER TABLE [dbo].[t_menu] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'ID',
'SCHEMA', N'dbo',
'TABLE', N't_menu',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'菜单名称',
'SCHEMA', N'dbo',
'TABLE', N't_menu',
'COLUMN', N'MenuName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'菜单地址',
'SCHEMA', N'dbo',
'TABLE', N't_menu',
'COLUMN', N'MenuUrl'
GO

EXEC sp_addextendedproperty
'MS_Description', N'菜单图标',
'SCHEMA', N'dbo',
'TABLE', N't_menu',
'COLUMN', N'MenuIcon'
GO

EXEC sp_addextendedproperty
'MS_Description', N'排序号',
'SCHEMA', N'dbo',
'TABLE', N't_menu',
'COLUMN', N'OrderNo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'父菜单',
'SCHEMA', N'dbo',
'TABLE', N't_menu',
'COLUMN', N'ParentId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'状态',
'SCHEMA', N'dbo',
'TABLE', N't_menu',
'COLUMN', N'Status'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N't_menu',
'COLUMN', N'CreateOn'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N't_menu',
'COLUMN', N'UpdateOn'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建者',
'SCHEMA', N'dbo',
'TABLE', N't_menu',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'编辑者',
'SCHEMA', N'dbo',
'TABLE', N't_menu',
'COLUMN', N'UpdateBy'
GO


-- ----------------------------
-- Records of [t_menu]
-- ----------------------------
SET IDENTITY_INSERT [dbo].[t_menu] ON
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'1', N'权限管理', NULL, N'icon-setting-permissions', N'0', N'0', N'1', N'2022-07-25 15:03:14.000', N'2022-07-26 17:11:25.000', N'0', N'1')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'2', N'菜单管理', N'/permissions/menu', N'icon-caidan', N'1', N'1', N'1', N'2022-07-25 15:03:20.000', N'2022-07-26 15:03:23.000', N'0', N'0')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'3', N'角色管理', N'/permissions/role', N'icon-jiaoseguanli', N'2', N'1', N'1', N'2022-07-25 15:03:25.000', N'2022-07-26 15:03:29.000', N'0', N'0')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'4', N'用户管理', N'/permissions/user', N'icon-yonghu', N'3', N'1', N'1', N'2022-07-25 15:03:32.000', N'2022-07-26 15:03:35.000', N'0', N'0')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'5', N'操作管理', N'/permissions/action', N'icon-shezhi', N'4', N'1', N'1', N'2022-07-25 15:03:39.000', N'2022-07-26 15:56:17.927', N'0', N'1')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'6', N'个人信息', NULL, N'icon-yonghu', N'0', N'0', N'1', N'2022-07-25 15:03:46.000', N'2022-07-28 16:55:20.590', N'0', N'1')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'8', N'基本资料', N'/SysSet/info', N'icon-jibenziliao', N'2', N'6', N'1', N'2022-07-25 15:03:56.000', N'2022-07-26 15:03:58.000', N'0', N'0')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'9', N'修改密码', N'/SysSet/password', N'icon-xiugaimima', N'3', N'6', N'1', N'2022-07-25 15:04:02.000', N'2022-07-26 15:04:05.000', N'0', N'0')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'12', N'信息管理', NULL, N'icon-ego-menu', N'0', N'0', N'1', N'2022-07-26 10:59:03.000', N'2022-07-26 15:30:46.020', N'1', N'1')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'13', N'信息菜单1', N'/permissions/pageTest', N'icon-chakan', N'0', N'12', N'1', N'2022-07-26 10:59:31.437', N'2022-07-26 10:59:31.437', N'1', N'1')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'14', N'信息菜单2', N'/permissions/pageTest', N'icon-chakan', N'0', N'12', N'1', N'2022-07-26 10:59:58.710', N'2022-07-26 10:59:58.710', N'1', N'1')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'15', N'宿舍管理', NULL, N'icon-yonghu', N'0', N'0', N'1', N'2022-07-26 11:00:26.300', N'2022-07-26 11:00:26.300', N'1', N'1')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'16', N'宿舍菜单1', N'/permissions/pageTest', N'icon-chakan', N'0', N'15', N'1', N'2022-07-26 11:00:50.020', N'2022-07-26 11:00:50.020', N'1', N'1')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'18', N'宿舍菜单2', N'/permissions/pageTest', N'icon-chakan', N'0', N'15', N'1', N'2022-07-26 11:01:37.507', N'2022-07-26 11:01:37.507', N'1', N'1')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'19', N'员工管理', NULL, N'icon-yonghu', N'0', N'0', N'1', N'2022-07-26 11:02:15.000', N'2022-07-26 15:31:20.850', N'1', N'1')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'20', N'员工菜单1', N'/permissions/pageTest', N'icon-chakan', N'0', N'19', N'1', N'2022-07-26 11:02:35.550', N'2022-07-26 11:02:35.550', N'1', N'1')
GO

INSERT INTO [dbo].[t_menu] ([Id], [MenuName], [MenuUrl], [MenuIcon], [OrderNo], [ParentId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'21', N'员工菜单2', N'/permissions/pageTest', N'icon-chakan', N'5', N'19', N'1', N'2022-07-26 11:02:57.000', N'2022-07-28 09:21:26.543', N'1', N'1')
GO

SET IDENTITY_INSERT [dbo].[t_menu] OFF
GO


-- ----------------------------
-- Table structure for t_menu_action
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[t_menu_action]') AND type IN ('U'))
	DROP TABLE [dbo].[t_menu_action]
GO

CREATE TABLE [dbo].[t_menu_action] (
  [MenuId] int  NOT NULL,
  [ActionId] int  NOT NULL
)
GO

ALTER TABLE [dbo].[t_menu_action] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'菜单ID',
'SCHEMA', N'dbo',
'TABLE', N't_menu_action',
'COLUMN', N'MenuId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作ID',
'SCHEMA', N'dbo',
'TABLE', N't_menu_action',
'COLUMN', N'ActionId'
GO


-- ----------------------------
-- Records of [t_menu_action]
-- ----------------------------
INSERT INTO [dbo].[t_menu_action]  VALUES (N'2', N'1')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'2', N'2')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'2', N'3')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'2', N'4')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'2', N'5')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'2', N'6')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'2', N'7')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'2', N'8')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'3', N'1')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'3', N'2')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'3', N'3')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'3', N'4')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'3', N'6')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'3', N'7')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'3', N'8')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'4', N'1')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'4', N'2')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'4', N'3')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'4', N'4')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'4', N'5')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'5', N'1')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'5', N'2')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'5', N'3')
GO

INSERT INTO [dbo].[t_menu_action]  VALUES (N'5', N'4')
GO


-- ----------------------------
-- Table structure for t_menu_role_action
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[t_menu_role_action]') AND type IN ('U'))
	DROP TABLE [dbo].[t_menu_role_action]
GO

CREATE TABLE [dbo].[t_menu_role_action] (
  [MenuId] int  NOT NULL,
  [RoleId] int  NOT NULL,
  [ActionId] int  NOT NULL
)
GO

ALTER TABLE [dbo].[t_menu_role_action] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'菜单ID',
'SCHEMA', N'dbo',
'TABLE', N't_menu_role_action',
'COLUMN', N'MenuId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'角色ID',
'SCHEMA', N'dbo',
'TABLE', N't_menu_role_action',
'COLUMN', N'RoleId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作ID',
'SCHEMA', N'dbo',
'TABLE', N't_menu_role_action',
'COLUMN', N'ActionId'
GO


-- ----------------------------
-- Records of [t_menu_role_action]
-- ----------------------------
INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'1', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'1', N'3', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'2', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'2', N'1', N'1')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'2', N'1', N'2')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'2', N'1', N'4')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'2', N'1', N'8')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'3', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'3', N'1', N'1')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'3', N'1', N'2')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'3', N'1', N'3')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'3', N'1', N'4')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'3', N'1', N'6')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'3', N'3', N'3')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'3', N'3', N'4')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'4', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'4', N'1', N'1')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'4', N'1', N'2')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'4', N'1', N'3')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'4', N'1', N'4')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'4', N'1', N'5')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'4', N'3', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'4', N'3', N'3')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'4', N'3', N'4')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'5', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'5', N'1', N'1')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'5', N'1', N'2')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'5', N'1', N'3')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'5', N'1', N'4')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'5', N'3', N'3')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'5', N'3', N'4')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'6', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'6', N'2', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'6', N'3', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'8', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'8', N'2', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'8', N'3', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'9', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'9', N'2', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'9', N'3', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'12', N'0', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'12', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'12', N'2', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'13', N'0', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'13', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'13', N'2', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'14', N'0', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'14', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'14', N'2', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'15', N'0', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'15', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'15', N'2', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'16', N'0', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'16', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'16', N'2', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'18', N'0', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'18', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'18', N'2', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'19', N'0', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'19', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'19', N'2', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'19', N'3', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'20', N'0', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'20', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'20', N'2', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'20', N'3', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'21', N'0', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'21', N'1', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'21', N'2', N'0')
GO

INSERT INTO [dbo].[t_menu_role_action]  VALUES (N'21', N'3', N'0')
GO


-- ----------------------------
-- Table structure for t_role
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[t_role]') AND type IN ('U'))
	DROP TABLE [dbo].[t_role]
GO

CREATE TABLE [dbo].[t_role] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [RoleCode] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [RoleName] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [Remark] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Status] bit  NULL,
  [CreateOn] datetime  NULL,
  [UpdateOn] datetime  NULL,
  [CreateBy] int  NULL,
  [UpdateBy] int  NULL
)
GO

ALTER TABLE [dbo].[t_role] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'ID',
'SCHEMA', N'dbo',
'TABLE', N't_role',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'角色编码',
'SCHEMA', N'dbo',
'TABLE', N't_role',
'COLUMN', N'RoleCode'
GO

EXEC sp_addextendedproperty
'MS_Description', N'角色名称',
'SCHEMA', N'dbo',
'TABLE', N't_role',
'COLUMN', N'RoleName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'角色描述',
'SCHEMA', N'dbo',
'TABLE', N't_role',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'状态(1:有效，0：无效)',
'SCHEMA', N'dbo',
'TABLE', N't_role',
'COLUMN', N'Status'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N't_role',
'COLUMN', N'CreateOn'
GO

EXEC sp_addextendedproperty
'MS_Description', N'更新时间',
'SCHEMA', N'dbo',
'TABLE', N't_role',
'COLUMN', N'UpdateOn'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建者',
'SCHEMA', N'dbo',
'TABLE', N't_role',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改者',
'SCHEMA', N'dbo',
'TABLE', N't_role',
'COLUMN', N'UpdateBy'
GO


-- ----------------------------
-- Records of [t_role]
-- ----------------------------
SET IDENTITY_INSERT [dbo].[t_role] ON
GO

INSERT INTO [dbo].[t_role] ([Id], [RoleCode], [RoleName], [Remark], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'1', N'SysAdmin', N'超级管理员', NULL, N'1', N'2022-07-25 15:34:59.000', N'2022-07-26 15:35:03.000', N'0', N'0')
GO

INSERT INTO [dbo].[t_role] ([Id], [RoleCode], [RoleName], [Remark], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'2', N'GeneralAdmin', N'普通管理员', NULL, N'1', N'2022-07-25 15:35:09.000', N'2022-07-26 15:35:06.000', N'0', N'0')
GO

INSERT INTO [dbo].[t_role] ([Id], [RoleCode], [RoleName], [Remark], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'3', N'GeneralUser', N'用户', NULL, N'1', N'2022-07-25 15:35:13.000', N'2022-07-26 16:06:39.007', N'0', N'1')
GO

SET IDENTITY_INSERT [dbo].[t_role] OFF
GO


-- ----------------------------
-- Table structure for t_user
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[t_user]') AND type IN ('U'))
	DROP TABLE [dbo].[t_user]
GO

CREATE TABLE [dbo].[t_user] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [UserName] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [RealName] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [PassWord] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Gender] int  NULL,
  [Phone] varchar(11) COLLATE Chinese_PRC_CI_AS  NULL,
  [Email] varchar(30) COLLATE Chinese_PRC_CI_AS  NULL,
  [Remark] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [HeadShot] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [RoleId] int  NULL,
  [Status] bit  NULL,
  [CreateOn] datetime  NULL,
  [UpdateOn] datetime  NULL,
  [CreateBy] int  NULL,
  [UpdateBy] int  NULL
)
GO

ALTER TABLE [dbo].[t_user] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'ID',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户名（登录）',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'UserName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'姓名',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'RealName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'密码',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'PassWord'
GO

EXEC sp_addextendedproperty
'MS_Description', N'性别（0：男，1：女）',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'Gender'
GO

EXEC sp_addextendedproperty
'MS_Description', N'手机',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'Phone'
GO

EXEC sp_addextendedproperty
'MS_Description', N'邮箱',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'Email'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'头像',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'HeadShot'
GO

EXEC sp_addextendedproperty
'MS_Description', N'角色ID',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'RoleId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'状态',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'Status'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'CreateOn'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改时间',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'UpdateOn'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建者',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'CreateBy'
GO

EXEC sp_addextendedproperty
'MS_Description', N'修改者',
'SCHEMA', N'dbo',
'TABLE', N't_user',
'COLUMN', N'UpdateBy'
GO


-- ----------------------------
-- Records of [t_user]
-- ----------------------------
SET IDENTITY_INSERT [dbo].[t_user] ON
GO

INSERT INTO [dbo].[t_user] ([Id], [UserName], [RealName], [PassWord], [Gender], [Phone], [Email], [Remark], [HeadShot], [RoleId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'1', N'admin', N'超级管理员', N'e10adc3949ba59abbe56e057f20f883e', N'1', N'11111111111', N'123456@qq.com', N'最高权限', N'/Upload/img/微信图片_20220729082928.jpg', N'1', N'1', N'2022-07-25 16:18:52.000', N'2022-07-29 08:30:13.570', N'0', N'1')
GO

INSERT INTO [dbo].[t_user] ([Id], [UserName], [RealName], [PassWord], [Gender], [Phone], [Email], [Remark], [HeadShot], [RoleId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'3', N'user', N'用户', N'e10adc3949ba59abbe56e057f20f883e', N'1', N'178899573', N'123456@qq.com', N'低级权限', NULL, N'3', N'1', N'2022-07-26 16:22:15.000', N'2022-07-27 17:42:06.050', N'0', N'1')
GO

INSERT INTO [dbo].[t_user] ([Id], [UserName], [RealName], [PassWord], [Gender], [Phone], [Email], [Remark], [HeadShot], [RoleId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'5', N'admincc1', NULL, N'e10adc3949ba59abbe56e057f20f883e', N'0', NULL, NULL, NULL, NULL, N'3', N'1', N'2022-11-14 14:30:46.227', N'2022-11-14 14:30:46.227', N'1', N'1')
GO

INSERT INTO [dbo].[t_user] ([Id], [UserName], [RealName], [PassWord], [Gender], [Phone], [Email], [Remark], [HeadShot], [RoleId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'6', N'admincc2', NULL, N'e10adc3949ba59abbe56e057f20f883e', N'0', NULL, NULL, NULL, NULL, N'3', N'1', N'2022-11-14 14:30:57.007', N'2022-11-14 14:30:57.007', N'1', N'1')
GO

INSERT INTO [dbo].[t_user] ([Id], [UserName], [RealName], [PassWord], [Gender], [Phone], [Email], [Remark], [HeadShot], [RoleId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'7', N'admincc3', NULL, N'e10adc3949ba59abbe56e057f20f883e', N'0', NULL, NULL, NULL, NULL, N'3', N'1', N'2022-11-14 14:31:06.967', N'2022-11-14 14:31:06.967', N'1', N'1')
GO

INSERT INTO [dbo].[t_user] ([Id], [UserName], [RealName], [PassWord], [Gender], [Phone], [Email], [Remark], [HeadShot], [RoleId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'8', N'admincc4', NULL, N'e10adc3949ba59abbe56e057f20f883e', N'0', NULL, NULL, NULL, NULL, N'3', N'1', N'2022-11-14 14:31:20.277', N'2022-11-14 14:31:20.277', N'1', N'1')
GO

INSERT INTO [dbo].[t_user] ([Id], [UserName], [RealName], [PassWord], [Gender], [Phone], [Email], [Remark], [HeadShot], [RoleId], [Status], [CreateOn], [UpdateOn], [CreateBy], [UpdateBy]) VALUES (N'9', N'admincc5', N'ZHANGSA', N'e10adc3949ba59abbe56e057f20f883e', N'0', NULL, NULL, NULL, NULL, N'3', N'1', N'2022-11-14 14:31:27.000', N'2022-11-14 14:31:44.237', N'0', N'1')
GO

SET IDENTITY_INSERT [dbo].[t_user] OFF
GO


-- ----------------------------
-- Table structure for t_user_role
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[t_user_role]') AND type IN ('U'))
	DROP TABLE [dbo].[t_user_role]
GO

CREATE TABLE [dbo].[t_user_role] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [UserId] int  NULL,
  [RoleId] int  NULL
)
GO

ALTER TABLE [dbo].[t_user_role] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table t_action
-- ----------------------------
ALTER TABLE [dbo].[t_action] ADD CONSTRAINT [PK_t_action] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table t_menu
-- ----------------------------
ALTER TABLE [dbo].[t_menu] ADD CONSTRAINT [PK_t_menu] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table t_menu_action
-- ----------------------------
ALTER TABLE [dbo].[t_menu_action] ADD CONSTRAINT [PK_t_menu_action] PRIMARY KEY CLUSTERED ([MenuId], [ActionId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table t_menu_role_action
-- ----------------------------
ALTER TABLE [dbo].[t_menu_role_action] ADD CONSTRAINT [PK_t_menu_role_action] PRIMARY KEY CLUSTERED ([MenuId], [RoleId], [ActionId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table t_role
-- ----------------------------
ALTER TABLE [dbo].[t_role] ADD CONSTRAINT [PK_t_role] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table t_user
-- ----------------------------
ALTER TABLE [dbo].[t_user] ADD CONSTRAINT [PK_t_user] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table t_user_role
-- ----------------------------
ALTER TABLE [dbo].[t_user_role] ADD CONSTRAINT [PK_t_user_role] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

