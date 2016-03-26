@if(Session::has('message-info'))
<div class="alert alert-info">
	<button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
	{{ Session::get('message-info') }}
</div>
@endif