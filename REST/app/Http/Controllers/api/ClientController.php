<?php

namespace App\Http\Controllers\Api;

use Illuminate\Http\Request;

use App\Http\Requests;
use App\Http\Controllers\Controller;

use App\Core\Entities\Client;

class ClientController extends Controller
{
    public function getClientes(Request $request){

    	$clients = Client::get();

    	return response()->json(['clients' => $clients])->setCallback($request->input('callback'));

    }

}
