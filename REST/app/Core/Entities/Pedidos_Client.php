<?php
namespace App\Core\Entities;
use Illuminate\Database\Eloquent\Model;

class PedidosClient extends Model
{
    protected $table = 't_clientes';
    protected $primaryKey = 'idCliente';
    protected $connection = 'bdpedidos';
}
