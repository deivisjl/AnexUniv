<template>
	<div>
	<loader  v-if="loading" height="200"></loader>

		<ul v-if="!loading" class="list-group">
	<!-- Listado de lecciones -->
        <!-- <li class="list-group-item">
            <div class="input-group">
                <input type="text" class="form-control" value="Lección #@h" readonly>
                <span class="input-group-btn">
                    <button class="btn btn-danger" type="button" title="Eliminar">
                        <i class="fa fa-trash"></i>
                    </button>
                    <button data-toggle="modal" data-target="#lesson-edit" class="btn btn-default" type="button" title="Editar">
                        <i class="fa fa-edit"></i>
                    </button>
                </span>
            </div>
        </li> -->

        <!-- Listado de las lecciones creadas -->
    <li v-for="item in lessons" class="list-group-item">
        <div class="row">
          <div class="col-xs-2">
            <input v-model="item.Order" min="1" max="100" type="number" class="form-control text-center">  
          </div>
          <div class="col-xs-10">
            <div class="input-group">
                <input type="text" class="form-control" :value="item.Name" readonly>
                <span class="input-group-btn">
                    <button  class="btn btn-danger" type="button" title="Eliminar">
                        <i class="fa fa-trash"></i>
                    </button>
                    <button  type="button" data-toggle="modal" data-target="#lesson-edit" class="btn btn-default" title="Editar">
                        <i class="fa fa-edit"></i>
                    </button>
                </span>
            </div>          
          </div>
        </div>
    </li>
    
    <!-- Nueva leccion -->
	    <li class="list-group-item">
	    <div v-if="newEntry.Error.length > 0" class="alert alert-danger">{{ newEntry }}</div>
	        <div class="input-group">

	            <input type="text"  v-model="newEntry.Name" class="form-control" placeholder="Nueva lección">
	            <span class="input-group-btn">
	                <button @click="insert" class="btn btn-default" type="button" title="Registrar">
	                    <i class="fa fa-plus"></i>
	                </button>
	            </span>
	        </div>
	    </li>
	</ul>
	</div>
</template>

<script>
import loader from './global.loader.vue';
export default{
	name: 'instructorlesson',
	components:{
		loader
	},
	props:{
		id:{
			type: Number,
			require: true
		}
	},
	data(){
		return{
			loading: false,
			newEntry:{
				Name: '',
				Error: ''
			},
			entry: {
		        Id: 0,
		        Name: '',
		        Content: '',
		        Video: '',
		        Order: 0,
		        Error: ''
		      },
		    lessons: []
		}
	},

	mounted(){
		this.all();
	},

	computed:{},

	methods:{
		all(){
			let self = this;
		      self.loading = true;

		      $.post('/instructor/GetAllLessons', {
		        courseId: self.id
		      }, function(r) {
		        self.lessons = r;
		        self.loading = false;
		      }, 'json')
		},
		get(){},
		update(){},
		insert(){
			let self = this;
			self.loading = true;

			$.post('/instructor/insertlesson',{
				courseId: self.id,
				Name: self.newEntry.Name
			},function(r){
				self.loading = false;

				if(!r.Response){
					self.newEntry.Error = r.Message;
				}else{
					self.newEntry.Name = '';
					self.newEntry.Error = '';
					
					self.all();
				}

			}, 'json')
		},
		delete(){}
	},
}

</script>