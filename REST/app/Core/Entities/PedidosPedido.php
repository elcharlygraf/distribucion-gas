<?php
namespace App\Core\Entities;
use Illuminate\Database\Eloquent\Model;

class PedidosPedido extends Model
{
    protected $table = 't_pedidos';
    protected $primaryKey = 'idPedido';
    protected $connection = 'bdpedidos';
}
