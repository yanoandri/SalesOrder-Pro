USE [AMSDAC]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_countStatus_versi2]    Script Date: 4/12/2015 9:42:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[fn_countStatus_versi2]
(
	@TYPE uniqueidentifier,
	@YEAR int,
	@department uniqueidentifier,
	@project uniqueidentifier,
	@auditor uniqueidentifier,
	@TYPENAME varchar(255)	
)
RETURNS int
AS
BEGIN
	DECLARE @CC_1 int SET @CC_1 = 0;

	--filter by ALL
	if @department is not null and @project is not null and @auditor is not null
	begin
		
		select
			@CC_1 = a.totala + b.totalb + c.totalc 
		from 
			(SELECT COUNT(*) AS totala FROM 
			audit_project ap left join audit_program apr 
				on ap.audit_project_code_id = apr.audit_project_code_id 
			left join audit_workpaper awp 
				on apr.audit_program_id = awp.audit_program_id 
			left join ref_audit_workpaper_status awp_status 
				on awp_status.ref_audit_workpaper_status_id = awp.ref_audit_workpaper_status_id
		where 
			ap.audit_project_code_id = @project 
			and ap.project_owner = @department 
			and apr.pic = @auditor 
			and awp_status.audit_workpaper_status_name is not null 
			and audit_year = @YEAR 
			and awp_status.audit_workpaper_status_name = @TYPENAME 
			and ap.is_latest = 1
			and ap.active = 1) a,
		(SELECT COUNT(*) AS totalb FROM 
			dbo.NON_AUDIT_PROJECT nap LEFT JOIN dbo.NON_AUDIT_WORKPAPER nawp
				ON nap.NON_AUDIT_PROJECT_ID = nawp.NON_AUDIT_PROJECT_ID
			LEFT JOIN dbo.REF_AUDIT_WORKPAPER_STATUS awp_status
				ON nawp.REF_NON_AUDIT_WORKPAPER_STATUS_ID = awp_status.REF_AUDIT_WORKPAPER_STATUS_ID	
		where 
			nap.non_audit_project_code_id = @project 
			and nap.project_owner = @department 
			and nap.mic = @auditor 
			and awp_status.AUDIT_WORKPAPER_STATUS_NAME is not null 
			and non_audit_year = @YEAR 
			and awp_status.AUDIT_WORKPAPER_STATUS_NAME = @TYPENAME 
			and nap.is_latest = 1
			and nap.active = 1)b,
		(SELECT COUNT(*) AS totalc FROM 
			TRAINING tr left join  dbo.REF_TRAINING_STATUS rts 
				on tr.REF_TRAINING_STATUS_ID = rts.REF_TRAINING_STATUS_ID 
		where 
			tr.training_id = @project 
			and tr.training_owner = @department  
			and rts.TRAINING_STATUS_NAME is not null 
			and training_year = @YEAR 
			and rts.TRAINING_STATUS_NAME = @TYPENAME 
			and tr.active = 1)c
	end
	
	--filter by department AND project ONLY
	else if @department is not null and @project is not null
	begin
		select 
			@CC_1 = a.totala + b.totalb + c.totalc 
		from 
			(SELECT COUNT(*) AS totala FROM 
			audit_project ap left join audit_program apr 
				on ap.audit_project_code_id = apr.audit_project_code_id 
			left join audit_workpaper awp 
				on apr.audit_program_id = awp.audit_program_id 
			left join ref_audit_workpaper_status awp_status 
				on awp_status.ref_audit_workpaper_status_id = awp.ref_audit_workpaper_status_id
		where 
			ap.audit_project_code_id = @project 
			and ap.project_owner = @department 
			and awp_status.audit_workpaper_status_name is not null 
			and audit_year = @YEAR 
			and awp_status.audit_workpaper_status_name = @TYPENAME 
			and ap.is_latest = 1
			and ap.active = 1) a,
		(SELECT COUNT(*) AS totalb FROM 
			dbo.NON_AUDIT_PROJECT nap LEFT JOIN dbo.NON_AUDIT_WORKPAPER nawp
				ON nap.NON_AUDIT_PROJECT_ID = nawp.NON_AUDIT_PROJECT_ID
			LEFT JOIN dbo.REF_AUDIT_WORKPAPER_STATUS awp_status
				ON nawp.REF_NON_AUDIT_WORKPAPER_STATUS_ID = awp_status.REF_AUDIT_WORKPAPER_STATUS_ID	
		where 
			nap.non_audit_project_code_id = @project 
			and nap.project_owner = @department 
			and awp_status.AUDIT_WORKPAPER_STATUS_NAME is not null 
			and non_audit_year = @YEAR 
			and awp_status.AUDIT_WORKPAPER_STATUS_NAME = @TYPENAME 
			and nap.is_latest = 1
			and nap.active = 1)b,
		(SELECT COUNT(*) AS totalc FROM 
			TRAINING tr left join  dbo.REF_TRAINING_STATUS rts 
				on tr.REF_TRAINING_STATUS_ID = rts.REF_TRAINING_STATUS_ID 
		where 
			tr.TRAINING_ID= @project 
			and tr.TRAINING_OWNER = @department 
			and rts.TRAINING_STATUS_NAME is not null 
			and TRAINING_YEAR = @YEAR 
			and rts.TRAINING_STATUS_NAME = @TYPENAME 
			and tr.active = 1)c

	end


	--filter by department AND auditor ONLY
	else if @department is not null and @auditor is not null
	begin
		select 
			@CC_1 = a.totala + b.totalb + c.totalc
		from 
			(SELECT COUNT(*) AS totala FROM 
			audit_project ap left join audit_program apr 
				on ap.audit_project_code_id = apr.audit_project_code_id 
			left join audit_workpaper awp 
				on apr.audit_program_id = awp.audit_program_id 
			left join ref_audit_workpaper_status awp_status 
				on awp_status.ref_audit_workpaper_status_id = awp.ref_audit_workpaper_status_id
		where 
			apr.pic = @auditor 
			and ap.project_owner = @department 
			and awp_status.audit_workpaper_status_name is not NULL 
			and audit_year = @YEAR
			and awp_status.audit_workpaper_status_name = @TYPENAME 
			and ap.is_latest = 1
			and ap.active = 1) a,
		(SELECT COUNT(*) AS totalb FROM 
			dbo.NON_AUDIT_PROJECT nap LEFT JOIN dbo.NON_AUDIT_WORKPAPER nawp
				ON nap.NON_AUDIT_PROJECT_ID = nawp.NON_AUDIT_PROJECT_ID
			LEFT JOIN dbo.REF_AUDIT_WORKPAPER_STATUS awp_status
				ON nawp.REF_NON_AUDIT_WORKPAPER_STATUS_ID = awp_status.REF_AUDIT_WORKPAPER_STATUS_ID
		where 
			nap.mic = @auditor 
			and nap.project_owner = @department 
			and awp_status.AUDIT_WORKPAPER_STATUS_NAME is not NULL 
			and non_audit_year = @YEAR
			and awp_status.AUDIT_WORKPAPER_STATUS_NAME = @TYPENAME 
			and nap.is_latest = 1
			and nap.active = 1)b,
		(SELECT COUNT(*) AS totalc FROM 
			TRAINING tr left join  dbo.REF_TRAINING_STATUS rts 
				on tr.REF_TRAINING_STATUS_ID = rts.REF_TRAINING_STATUS_ID 
		where 
			tr.TRAINING_OWNER = @department 
			and rts.TRAINING_STATUS_NAME is not NULL 
			and TRAINING_YEAR = @YEAR
			and rts.TRAINING_STATUS_NAME = @TYPENAME 
			and tr.active = 1)c

	end


	--filter by auditor AND project ONLY
	else if @auditor is not null and @project is not null
	begin
		select 
			@CC_1 = a.totala + b.totalb + c.totalc --ap.project_name, apr.process_description, awp.work_performed, awp_status.audit_workpaper_status_name
		from 
			(SELECT COUNT(*) AS totala FROM 
			audit_project ap left join audit_program apr 
				on ap.audit_project_code_id = apr.audit_project_code_id 
			left join audit_workpaper awp 
				on apr.audit_program_id = awp.audit_program_id 
			left join ref_audit_workpaper_status awp_status 
				on awp_status.ref_audit_workpaper_status_id = awp.ref_audit_workpaper_status_id
		where 
			apr.pic = @auditor 
			and ap.audit_project_code_id = @project 
			and awp_status.audit_workpaper_status_name is not null 
			and audit_year = @YEAR 
			and awp_status.audit_workpaper_status_name = @TYPENAME 
			and ap.is_latest = 1
			and ap.active = 1) a,
		(SELECT COUNT(*) AS totalb FROM 
				dbo.NON_AUDIT_PROJECT nap LEFT JOIN dbo.NON_AUDIT_WORKPAPER nawp
				ON nap.NON_AUDIT_PROJECT_ID = nawp.NON_AUDIT_PROJECT_ID
			LEFT JOIN dbo.REF_AUDIT_WORKPAPER_STATUS awp_status
				ON nawp.REF_NON_AUDIT_WORKPAPER_STATUS_ID = awp_status.REF_AUDIT_WORKPAPER_STATUS_ID	
		where 
			nap.MIC = @auditor 
			and nap.non_audit_project_code_id = @project 
			and awp_status.AUDIT_WORKPAPER_STATUS_NAME is not null 
			and non_audit_year = @YEAR 
			and awp_status.AUDIT_WORKPAPER_STATUS_NAME = @TYPENAME 
			and nap.is_latest = 1
			and nap.active = 1)b,
		(SELECT COUNT(*) AS totalc FROM 
			TRAINING tr left join  dbo.REF_TRAINING_STATUS rts 
				on tr.REF_TRAINING_STATUS_ID = rts.REF_TRAINING_STATUS_ID 
		where 
			tr.TRAINING_OWNER = @auditor 
			and tr.TRAINING_ID= @project 
			and rts.TRAINING_STATUS_NAME is not null 
			and TRAINING_YEAR = @YEAR 
			and rts.TRAINING_STATUS_NAME = @TYPENAME 
			and tr.active = 1)c

	end

	--filter by department ONLY
	else if @department is not null
	begin
		SELECT 
			@CC_1 = a.totala + b.totalb + c.totalc
		FROM 
			(SELECT COUNT(*) AS totala FROM 
			audit_project ap
		WHERE 
			audit_year = @YEAR 
			and ap.ref_project_status_id = @TYPE 
			and (ap.project_owner = @department or '00000000-0000-0000-0000-000000000000' = @department)
			and ap.is_latest = 1
			and ap.active = 1) a,
		(SELECT COUNT(*) AS totalb FROM 
			non_audit_project nap
		WHERE 
			non_audit_year = @YEAR 
			and nap.ref_project_status_id = @TYPE 
			and (nap.project_owner = @department or '00000000-0000-0000-0000-000000000000' = @department)
			and nap.is_latest = 1
			and nap.active = 1)b,
		(SELECT COUNT(*) AS totalc FROM 
			TRAINING tr 
		where 
			TRAINING_YEAR = @YEAR 
			and tr.REF_TRAINING_STATUS_ID = @TYPE 
			and (tr.TRAINING_OWNER = @department or '00000000-0000-0000-0000-000000000000' = @department)
			and tr.active = 1)c

	end


	--filter by project ONLY
	else if @project is not null
	begin
		select 
			@CC_1 = a.totala +b.totalb +c.totalc 
		FROM 
		(SELECT COUNT(*) AS totala FROM 
			audit_project ap left join audit_program apr 
				on ap.audit_project_code_id = apr.audit_project_code_id 
			left join audit_workpaper awp 
				on apr.audit_program_id = awp.audit_program_id 
			left join ref_audit_workpaper_status awp_status 
				on awp_status.ref_audit_workpaper_status_id = awp.ref_audit_workpaper_status_id
		where 
			ap.audit_project_code_id = @project 
			and awp_status.audit_workpaper_status_name is not null 
			and ap.audit_year = @YEAR 
			and awp_status.audit_workpaper_status_name = @TYPENAME 
			and ap.is_latest = 1
			and ap.active = 1) a,
		(SELECT COUNT(*) AS totalb FROM 
			dbo.NON_AUDIT_PROJECT nap LEFT JOIN dbo.NON_AUDIT_WORKPAPER nawp
				ON nap.NON_AUDIT_PROJECT_ID = nawp.NON_AUDIT_PROJECT_ID
			LEFT JOIN dbo.REF_AUDIT_WORKPAPER_STATUS awp_status
				ON nawp.REF_NON_AUDIT_WORKPAPER_STATUS_ID = awp_status.REF_AUDIT_WORKPAPER_STATUS_ID	
		where 
			nap.NON_AUDIT_PROJECT_CODE_ID = @project 
			and awp_status.AUDIT_WORKPAPER_STATUS_NAME is not null 
			and nap.non_audit_year = @YEAR 
			and awp_status.AUDIT_WORKPAPER_STATUS_NAME = @TYPENAME 
			and nap.is_latest = 1
			and nap.active = 1)b,
		(SELECT COUNT(*) AS totalc FROM 
			TRAINING tr left join  dbo.REF_TRAINING_STATUS rts 
				on tr.REF_TRAINING_STATUS_ID = rts.REF_TRAINING_STATUS_ID 
		where 
			tr.TRAINING_ID = @project 
			and rts.TRAINING_STATUS_NAME is not null 
			and tr.TRAINING_YEAR = @YEAR 
			and rts.TRAINING_STATUS_NAME = @TYPENAME 
			and tr.active = 1)c

	end
	--filter by auditor ONLY
	else if @auditor is not null
	begin
		select 
			@CC_1 = a.totala + b.totalb + c.totalc --ap.project_name, apr.process_description, awp.work_performed, awp_status.audit_workpaper_status_name
		from 
			(SELECT COUNT(*) AS totala FROM 
			audit_project ap left join audit_program apr 
				on ap.audit_project_code_id = apr.audit_project_code_id 
			left join audit_workpaper awp 
				on apr.audit_program_id = awp.audit_program_id 
			left join ref_audit_workpaper_status awp_status 
				on awp_status.ref_audit_workpaper_status_id = awp.ref_audit_workpaper_status_id
		where 
			apr.pic = @auditor 
			and awp_status.audit_workpaper_status_name is not null 
			and audit_year = @YEAR 
			and awp_status.audit_workpaper_status_name = @TYPENAME 
			and ap.is_latest = 1) a,
		(SELECT COUNT(*) AS totalb FROM 
			dbo.NON_AUDIT_PROJECT nap LEFT JOIN dbo.NON_AUDIT_WORKPAPER nawp
				ON nap.NON_AUDIT_PROJECT_ID = nawp.NON_AUDIT_PROJECT_ID
			LEFT JOIN dbo.REF_AUDIT_WORKPAPER_STATUS awp_status
				ON nawp.REF_NON_AUDIT_WORKPAPER_STATUS_ID = awp_status.REF_AUDIT_WORKPAPER_STATUS_ID			          
		where 
			nap.MIC = @auditor 
			and awp_status.AUDIT_WORKPAPER_STATUS_NAME is not null 
			and non_audit_year = @YEAR 
			and awp_status.AUDIT_WORKPAPER_STATUS_NAME = @TYPENAME 
			and nap.is_latest = 1
			and nap.active = 1)b,
		(SELECT COUNT(*) AS totalc FROM 
			TRAINING tr left join dbo.REF_TRAINING_STATUS rts 
				on tr.REF_TRAINING_STATUS_ID = rts.REF_TRAINING_STATUS_ID 
		where 
			tr.TRAINING_OWNER = @auditor
			and rts.TRAINING_STATUS_NAME is not null 
			and tr.TRAINING_YEAR = @YEAR 
			and rts.TRAINING_STATUS_NAME = @TYPENAME 
			and tr.active = 1)c

	end
	--no filter audit, non audit dan training
	else
	begin
		SELECT @CC_1 = a.totala + b.totalb + c.totalc FROM 
		(select
			COUNT(*) AS totala
		FROM 
			audit_project ap 
		WHERE 
			audit_year = @YEAR 
			and ap.ref_project_status_id = @TYPE 
			and ap.is_latest = 1
			and ap.active = 1) a,
		(select
			COUNT(*) AS totalb
		FROM 
			non_audit_project nap 
		WHERE 
			non_audit_year = @YEAR 
			and nap.ref_project_status_id = @TYPE 
			and nap.is_latest = 1
			and nap.active = 1) b,
		(select
			COUNT(*) AS totalc
		FROM 
			dbo.TRAINING tr 
		WHERE 
			TRAINING_YEAR = @YEAR 
			and tr.REF_TRAINING_STATUS_ID = @TYPE 
			and tr.active = 1)c

	end
	-- Return the result of the function


/*
if @project is not null or @auditor is not null or @department is not null
  begin
	select 
		@CC_1 = count(*)
	from 
		audit_project ap left join audit_program apr on ap.audit_project_id = apr.audit_project_code_id left join audit_workpaper awp on apr.audit_program_id = awp.audit_program_id left join ref_audit_workpaper_status awp_status on awp_status.ref_audit_workpaper_status_id = awp.ref_audit_workpaper_status_id
	where 
		(ap.audit_project_id = @project or @project is null) and 
		(ap.project_owner = @department or @department is null) and 
		(apr.pic = @auditor or @auditor is null) and 
		awp_status.audit_workpaper_status_name is not null and 
		audit_year = @YEAR and 
		awp_status.audit_workpaper_status_name = @TYPENAME and 
		ap.is_latest = 1
  end
else
  begin
	SELECT @CC_1 = count(*)
	FROM audit_project ap
	WHERE audit_year = @YEAR and ap.ref_project_status_id = @TYPE and ap.is_latest = 1
  end
*/
	RETURN @CC_1

END


--select count(ref_project_status_id) from audit_project where audit_year = '2010' and is_latest =1  group by ref_project_status_id






