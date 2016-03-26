<?php

namespace App\Http\Controllers\Api;

use Illuminate\Http\Request;

use App\Http\Requests;
use App\Http\Controllers\Controller;

use App\Core\Entities\Productos;

class ProductController extends Controller
{
    public function getProducts(Request $request){

    	$products = Productos::get();

    	return response()->json(['products' => $products])->setCallback($request->input('callback'));

    }

}
