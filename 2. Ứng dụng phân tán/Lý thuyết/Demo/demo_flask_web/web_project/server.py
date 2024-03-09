from flask import jsonify, request
from flask import Flask
from flask import render_template
import web_project.utils as utils

# Create the application instance
app = Flask(__name__, template_folder="web/templates")


@app.route('/test/', methods=['GET'])
def test():
    return jsonify({"message": "hello abc"})


@app.route('/tinh_tong/', methods=['GET'])
def tinh_tong():
    a = request.args.get("a")
    b = request.args.get("b")
    result = int(a) + int(b)
    return jsonify({
        "a": a,
        "b": b,
        "result": result})


@app.route('/tinh_nhan/', methods=['POST'])
def tinh_nhan():
    a = request.form['a']
    b = request.form['b']
    result = int(a) * int(b)
    return jsonify({
        "a": a,
        "b": b,
        "result": result})


@app.route('/hello/', methods=['GET'])
def hello():
    a = request.args.get("so1")
    b = request.args.get("so2")
    result = None
    if a is not None and b is not None:
        result = int(a) + int(b)
        print(result)
    # return jsonify({"message": "hello"})
    return render_template("hello.html", result=result, xyz=1000)


@app.route('/hello2/', methods=['GET'])
def hello2():
    return render_template("hello2.html", data="hello 2 page")

@app.route('/hello3/', methods=['GET'])
def hello3():
    return render_template("hello3.html", data="hello 3 page")


@app.route('/hello4/', methods=['GET'])
def hello4():
    return render_template("hello4.html", data="hello 4 page")


@app.route('/hello5/', methods=['GET'])
def hello5():
    return render_template("hello5.html", data="hello 5 page")

# # Create a URL route in our application for "/"
# @app.route('/', methods=['GET'])
# def index():
#     # return render_template("home.html")
#     return jsonify({"message": "api is running"})



@app.route('/search_api/', methods=['GET'])
def search_api():
    q = request.args.get("question")
    if q:
        docs = utils.search(q)
    else:
        docs = []
    return jsonify(docs)

#
# @app.route('/classify_api', methods=['GET', 'POST'])
# def classify_api():
#     # docs_new = ['what is computer',
#     #             'who is Newton',
#     #             'when is the Tet holiday ?']
#     # return jsonify(utils.classify(docs_new))
#
#     if request.method == 'POST':
#         q = request.form['question']
#     else:  # method = GET
#         # http://0.0.0.0:9999/classify_api?question=who is the president of US
#         q = request.args.get("question")
#
#     if q:
#         result = utils.classify(docs=[q])[0]
#     else:
#         result = []
#     return jsonify(result)
#

@app.route('/search/', methods=['POST', 'GET'])
def search_page():
    question = request.args.get("question")
    if question:
        docs = utils.search(question)
    else:
        docs = []

    return render_template("search.html", docs=docs, question=question)


@app.route('/classify/', methods=['POST', 'GET'])
def classify_page():
    if 'question' in request.form:
        questions = request.form['question'].strip().split("\n")
        result = utils.classify(questions)
    else:
        questions = []
        result = None
    data = {
        "result": result,
        "question": "\n".join(questions)
    }
    return render_template("classify.html", data=data)

#
# @app.route('/page0/', methods=['POST', 'GET'])
# def page0():
#     return render_template("page0.html", text="helllo A")
#
#
# @app.route('/page1/', methods=['POST', 'GET'])
# def page1():
#     question = request.args.get("question")
#     if question:
#         docs = utils.search(question)
#     else:
#         docs = []
#
#     return render_template("page1.html", docs=docs, question=question)
#
#
@app.route('/', methods=['POST', 'GET'])
def home():
    return render_template("home.html")


if __name__ == '__main__':
    app.run(debug=True, host="0.0.0.0", port="9999")



