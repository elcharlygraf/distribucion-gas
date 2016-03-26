<?php

Route::group( ['prefix'=>'api', 'namespace' => 'api', 'as' => 'api::'], function() {
	
	//CLIENTES
	Route::group( ['prefix'=>'clients'], function() {
		
		Route::get('/{id?}', ['as' => 'getClientes', 'uses' => 'ClientController@getClientes']);

	});

	//PEDIDOS
	Route::group( ['prefix'=>'delivery'], function() {
		
		Route::get('/{id?}', ['as' => 'getDelivery', 'uses' => 'DeliveryController@getDelivery']);

	});

});

Route::group( ['prefix'=>'/', 'as' => 'home::'], function() {
	
	//INICIO
	Route::get('/', ['as' => 'getIndex', 'uses' => 'HomeController@index']);
});