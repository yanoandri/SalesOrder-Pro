ALTER PROCEDURE dbo.spx_projecttrackingdashboard_get_project_overview
	@YEARDD int,
	@department uniqueidentifier,
	@project uniqueidentifier,
	@auditor uniqueidentifier
		
as
	select project_status_name as Status,dbo.fn_countStatus_versi2(ref_project_status_id,@yeardd,@department,@project,@auditor,project_status_name) as Value
	,
	Color =
	case
	when project_status_name in ('Not Yet Performed') then '#a6a6a6'
	when project_status_name in ('In Progress') then '#95b3d7'
	when project_status_name in ('Completed') then '#16365c'
	end
	from ref_project_status
	where active = 1
	order by sort_number
GO
