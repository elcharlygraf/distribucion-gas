<?php
namespace App\Core\Entities;
use Illuminate\Database\Eloquent\Model;

class Client extends Model
{
    protected $table = 't_clientes';
    protected $primaryKey = 'idCliente';
}
