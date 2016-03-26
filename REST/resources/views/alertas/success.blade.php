@if(Session::has('message-success'))
<div class="alert alert-success">
	<button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
	<strong>En hora buena!</strong> {{ Session::get('message-success') }}
</div>
@endif